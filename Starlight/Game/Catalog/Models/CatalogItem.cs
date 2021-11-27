using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;

namespace Starlight.Game.Catalog.Models
{
	public class CatalogItem : ICatalogItem
	{
		public int Id { get; }
		public string ItemIds { get; }
		public int PageId { get; }
		public string Name { get; }
		public int Credits { get; }
		public int Points { get; }
		public int PointsType { get; }
		public int ClubLevel { get; }
		public bool CanGift { get; }
		public bool HasOffer { get; }
		public int OfferId { get; }
		public int BotId { get; }
		public string Badge { get; set; }
		public int LimitedStack { get; }
		public IList<ICatalogItemData> Items { get; set; }

		public void Compose(IServerMessage message)
		{
			message.WriteInt(Id);
			message.WriteString(Name);
			message.WriteBoolean(false);
			message.WriteInt(Credits);
			message.WriteInt(Points);
			message.WriteInt(PointsType);
			message.WriteBoolean(CanGift);

			message.WriteInt(Items.Count);
			foreach (CatalogItemData item in Items)
			{
				message.WriteString(item.ItemData.Type);
				message.WriteInt(item.ItemData.SpriteId);
				message.WriteString(item.Extradata);
				message.WriteInt(item.Amount);

				message.WriteBoolean(false); // limited
				{
					//message.WriteInt(0); // total in set
					//message.WriteInt(0); // total left
				}
			}

			message.WriteInt(ClubLevel);
			message.WriteBoolean(HasOffer);
			message.WriteBoolean(false);
			message.WriteString(Name + ".png");
		}
	}
}