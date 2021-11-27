using Starlight.API.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.API.Game.Catalog.Models
{
	public interface ICatalogItem
	{
		int Id { get; }
		string ItemIds { get; }
		int PageId { get; }
		string Name { get; }
		int Credits { get; }
		int Points { get; }
		int PointsType { get; }
		int ClubLevel { get; }
		bool CanGift { get; }
		bool HasOffer { get; }
		int OfferId { get; }
		int BotId { get; }
		string Badge { get; set; }
		int LimitedStack { get; }
		IList<ICatalogItemData> Items { get; set; }

		void Compose(IServerMessage message);
	}
}