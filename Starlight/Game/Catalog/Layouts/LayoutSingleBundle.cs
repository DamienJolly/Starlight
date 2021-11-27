using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutSingleBundle : CatalogLayout
	{
		public LayoutSingleBundle(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("single_bundle");
			message.WriteInt(3);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteString("");
			message.WriteInt(4);
			message.WriteString(CatalogPage.TextOne);
			message.WriteString(CatalogPage.TextDetails);
			message.WriteString(CatalogPage.TextTeaser);
			message.WriteString(CatalogPage.TextTwo);
		}
	}
}