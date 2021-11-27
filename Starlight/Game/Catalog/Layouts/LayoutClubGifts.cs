using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutClubGifts : CatalogLayout
	{
		public LayoutClubGifts(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("club_gifts");
			message.WriteInt(1);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteInt(1);
			message.WriteString(CatalogPage.TextOne);
		}
	}
}