using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutInfoRentables : CatalogLayout
	{
		public LayoutInfoRentables(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("info_rentables");
			message.WriteInt(1);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteInt(0);
			message.WriteInt(0);
		}
	}
}