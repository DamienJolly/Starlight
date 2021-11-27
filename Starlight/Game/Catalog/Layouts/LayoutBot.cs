using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutBot : CatalogLayout
	{
		public LayoutBot(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("bots");
			message.WriteInt(2);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteInt(3);
			message.WriteString(CatalogPage.TextOne);
			message.WriteString(CatalogPage.TextDetails);
			message.WriteString(CatalogPage.TextTwo);
		}
	}
}