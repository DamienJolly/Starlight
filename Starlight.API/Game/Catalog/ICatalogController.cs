using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;

namespace Starlight.API.Game.Catalog
{
	public interface ICatalogController
	{
		IDictionary<int, ICatalogPage> GetCatalogPages(string mode);
	}
}
