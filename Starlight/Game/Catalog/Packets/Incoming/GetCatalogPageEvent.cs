using Starlight.API.Communication.Messages;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Catalog.Packets.Incoming.Args;
using Starlight.Game.Catalog.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Packets.Incoming
{
    public class GetCatalogPageEvent : AbstractMessageEvent<CatalogPageArgs>
    {
        public override short Header => Headers.GetCatalogPageEvent;

        private readonly ICatalogController _catalogController;

        public GetCatalogPageEvent(ICatalogController catalogController)
        {
            _catalogController = catalogController;
        }

        protected override async Task HandleAsync(ISession session, CatalogPageArgs args)
        {
            if (!_catalogController.TryGetCatalogPage(args.PageId, args.Mode, out ICatalogPage catalogPage))
                return;

            if (catalogPage.Rank > session.Player.PlayerData.Rank || !catalogPage.Enabled)
                return;

            IList<ICatalogFeaturedPage> featuredPages = _catalogController.GetFeaturedPages();

            await session.WriteAndFlushAsync(new CatalogPageComposer(args.Mode, catalogPage, featuredPages));
        }
    }
}
