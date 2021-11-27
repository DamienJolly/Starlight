using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutSoldLTDItems : CatalogLayout
	{
		public LayoutSoldLTDItems(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("sold_ltd_items");
			message.WriteInt(3);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteString(CatalogPage.SpecialImage);
			message.WriteInt(0);
		}
	}
}