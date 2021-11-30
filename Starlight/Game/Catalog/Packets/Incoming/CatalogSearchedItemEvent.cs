using Starlight.API.Communication.Messages;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Catalog.Packets.Incoming.Args;
using Starlight.Game.Catalog.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Packets.Incoming
{
	public class CatalogSearchedItemEvent : AbstractMessageEvent<SearchItemArgs>
	{
		public override short Header => Headers.CatalogSearchedItemEvent;

		private readonly ICatalogController _catalogController;

		public CatalogSearchedItemEvent(ICatalogController catalogController)
		{
			_catalogController = catalogController;
		}

		protected override async ValueTask Execute(ISession session, SearchItemArgs args)
		{
			if (args.OfferId == -1)
				return;

			ICatalogItem catalogItem = _catalogController.GetCatalogItemByOfferId(args.OfferId);
			if (catalogItem == null)
				return;

			await session.WriteAndFlushAsync(new CatalogSearchResultComposer(catalogItem));
		}
	}
}