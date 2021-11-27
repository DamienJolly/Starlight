using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutMarketplaceOwnItems : CatalogLayout
	{
		public LayoutMarketplaceOwnItems(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("marketplace_own_items");
			message.WriteInt(0);
			message.WriteInt(0);
		}
	}
}