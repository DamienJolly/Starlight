using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.API.Game.Catalog.Layouts
{
	public abstract class CatalogLayout
	{
		public ICatalogPage CatalogPage { get; private set; }

		public CatalogLayout(ICatalogPage catalogPage)
		{
			CatalogPage = catalogPage;
		}

		public abstract void ComposePageData(IServerMessage message);
	}
}
