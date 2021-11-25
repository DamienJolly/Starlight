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
    public class GetCatalogModeEvent : AbstractMessageEvent<CatalogModeArgs>
    {
        public override short Header => Headers.GetCatalogModeEvent;

        private readonly ICatalogController _catalogController;

        public GetCatalogModeEvent(ICatalogController catalogController)
        {
            _catalogController = catalogController;
        }

        protected override async Task HandleAsync(ISession session, CatalogModeArgs args)
        {
            IDictionary<int, ICatalogPage> catalogPages = _catalogController.GetCatalogPages(args.Mode);

            await session.WriteAndFlushAsync(new CatalogPagesListComposer(session.Player, args.Mode, catalogPages));
        }
    }
}
