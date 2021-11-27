using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutRecycler : CatalogLayout
	{
		public LayoutRecycler(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("recycler");
			message.WriteInt(2);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteInt(1);
			message.WriteString(CatalogPage.TextOne);
			message.WriteInt(-1);
			message.WriteBoolean(false);
		}
	}
}