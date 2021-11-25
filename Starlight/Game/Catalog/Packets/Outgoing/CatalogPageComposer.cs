using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class CatalogPageComposer : MessageComposer
    {
        private readonly string Mode;
        private readonly ICatalogPage CatalogPage;

        public CatalogPageComposer(string mode, ICatalogPage catalogPage) : base(Headers.CatalogPageComposer)
        {
            Mode = mode;
            CatalogPage = catalogPage;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(CatalogPage.Id);
            message.WriteString(Mode);

            CatalogPage.PageLayout.ComposePageData(message);

            message.WriteInt(0); // Catalog items count

            message.WriteInt(0);
            message.WriteBoolean(false);

            // Is frontpage
            message.WriteInt(0); // Featured pages count
        }
	}
}
