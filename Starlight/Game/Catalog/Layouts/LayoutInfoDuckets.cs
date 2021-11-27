using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutInfoDuckets : CatalogLayout
	{
		public LayoutInfoDuckets(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("info_duckets");
			message.WriteInt(1);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteInt(1);
			message.WriteString(CatalogPage.TextOne);
			message.WriteInt(0);
		}
	}
}