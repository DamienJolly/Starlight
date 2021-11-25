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

            // Layouts
            /* message.WriteString("default_3x3");
             message.WriteInt(3);
             message.WriteString(CatalogPage.HeaderImage);
             message.WriteString(CatalogPage.TeaserImage);
             message.WriteString(CatalogPage.SpecialImage);
             message.WriteInt(3);
             message.WriteString(CatalogPage.TextOne);
             message.WriteString(CatalogPage.TextDetails);
             message.WriteString(CatalogPage.TextTeaser);*/

            message.WriteString("frontpage4");
            message.WriteInt(2);
            message.WriteString(CatalogPage.HeaderImage);
            message.WriteString(CatalogPage.TeaserImage);
            message.WriteInt(3);
            message.WriteString(CatalogPage.TextOne);
            message.WriteString(CatalogPage.TextTwo);
            message.WriteString(CatalogPage.TextTeaser);

            message.WriteInt(0); // Catalog items count

            message.WriteInt(0);
            message.WriteBoolean(false);

            // Is frontpage
            message.WriteInt(0); // Featured pages count
        }
	}
}
