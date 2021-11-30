using Starlight.API.Communication.Messages;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Catalog.Packets.Incoming.Args;
using Starlight.Game.Catalog.Packets.Outgoing;
using Starlight.Game.Players.Packets.Outgoing;
using System;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Packets.Incoming
{
	public class PurchaseFromCatalogEvent : AbstractMessageEvent<PurchaseItemArgs>
	{
		public override short Header => Headers.PurchaseFromCatalogEvent;

		private static readonly string MODE = "NORMAL";
		private readonly ICatalogController _catalogController;

		public PurchaseFromCatalogEvent(ICatalogController catalogController)
		{
			_catalogController = catalogController;
		}

		protected override async ValueTask Execute(ISession session, PurchaseItemArgs args)
		{
			int pageId = args.PageId;

			if (!_catalogController.TryGetCatalogItem(args.ItemId, MODE, out ICatalogItem catalogItem))
			{
				await session.WriteAndFlushAsync(new PurchaseErrorComposer(PurchaseErrorComposer.SERVER_ERROR));
				return;
			}

			if (pageId <= 0)
			{
				if (catalogItem.OfferId == -1)
				{
					await session.WriteAndFlushAsync(new PurchaseNotAllowedComposer(PurchaseNotAllowedComposer.ILLEGAL));
					return;
				}

				pageId = catalogItem.PageId;
			}

			if (!_catalogController.TryGetCatalogPage(pageId, MODE, out ICatalogPage page) || page.Id != catalogItem.PageId)
			{
				await session.WriteAndFlushAsync(new PurchaseErrorComposer(PurchaseErrorComposer.SERVER_ERROR));
				return;
			}

			if (page.Rank > session.Player.PlayerData.Rank)
			{
				await session.WriteAndFlushAsync(new PurchaseNotAllowedComposer(PurchaseNotAllowedComposer.ILLEGAL));
				return;
			}

			/*if (catalogItem.ClubLevel)
			{
				await session.WriteAndFlushAsync(new PurchaseNotAllowedComposer(PurchaseNotAllowedComposer.REQUIRES_CLUB));
				return;
			}*/

			if (args.Amount <= 0 || args.Amount > 100)
			{
				await session.WriteAndFlushAsync(new PurchaseErrorComposer(PurchaseErrorComposer.SERVER_ERROR));
				return;
			}

			if (args.Amount > 1 && !catalogItem.HasOffer)
			{
				await session.WriteAndFlushAsync(new PurchaseNotAllowedComposer(PurchaseNotAllowedComposer.ILLEGAL));
				return;
			}

			// Todo: Limited items

			int totalCredits = CalculateDiscountedPrice(catalogItem.Credits, args.Amount);
			int totalPoints = CalculateDiscountedPrice(catalogItem.Points, args.Amount);

			if (session.Player.PlayerData.Credits < totalCredits) // not enough credits; player is most likely scripting.
				return;

			// Todo: Points check

			foreach (ICatalogItemData itemData in catalogItem.Items)
			{
				// Todo: Purchase items
			}

			if (totalCredits > 0)
			{
				session.Player.PlayerData.Credits -= catalogItem.Credits;
				await session.WriteAndFlushAsync(new PlayerCreditsComposer(session.Player.PlayerData.Credits));
			}

			// Todo: Remove points

			await session.WriteAndFlushAsync(new PurchaseOKComposer(catalogItem));
		}

		private int CalculateDiscountedPrice(int originalPrice, int amount)
		{
			int basicDiscount = amount / DiscountComposer.DISCOUNT_BATCH_SIZE;

			int bonusDiscount = 0;
			if (basicDiscount >= DiscountComposer.MINIMUM_DISCOUNTS_FOR_BONUS)
			{
				if (amount % DiscountComposer.DISCOUNT_BATCH_SIZE == DiscountComposer.DISCOUNT_BATCH_SIZE - 1)
				{
					bonusDiscount = 1;
				}

				bonusDiscount += basicDiscount - DiscountComposer.MINIMUM_DISCOUNTS_FOR_BONUS;
			}

			int additionalDiscounts = 0;
			foreach (int threshold in DiscountComposer.ADDITIONAL_DISCOUNT_THRESHOLDS)
			{
				if (amount >= threshold) additionalDiscounts++;
			}

			int totalDiscountedItems = (basicDiscount * DiscountComposer.DISCOUNT_AMOUNT_PER_BATCH) + bonusDiscount + additionalDiscounts;

			return Math.Max(0, originalPrice * (amount - totalDiscountedItems));
		}
	}
}