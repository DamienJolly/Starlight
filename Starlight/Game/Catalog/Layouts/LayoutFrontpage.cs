using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
    public class LayoutFrontpage : CatalogLayout
    {
        public LayoutFrontpage(ICatalogPage catalogPage) : base(catalogPage)
        {

        }

        public override void ComposePageData(IServerMessage message)
        {
            message.WriteString("frontpage4");
            message.WriteInt(2);
            message.WriteString(CatalogPage.HeaderImage);
            message.WriteString(CatalogPage.TeaserImage);
            message.WriteInt(3);
            message.WriteString(CatalogPage.TextOne);
            message.WriteString(CatalogPage.TextTwo);
            message.WriteString(CatalogPage.TextTeaser);
        }
    }
}
