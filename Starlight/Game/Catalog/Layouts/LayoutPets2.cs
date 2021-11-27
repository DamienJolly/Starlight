using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutPets2 : CatalogLayout
	{
		public LayoutPets2(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("pets2");
			message.WriteInt(2);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteInt(4);
			message.WriteString(CatalogPage.TextOne);
			message.WriteString(CatalogPage.TextTwo);
			message.WriteString(CatalogPage.TextDetails);
			message.WriteString(CatalogPage.TextTeaser);
		}
	}
}