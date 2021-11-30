using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.Catalog
{
	public interface ICatalogController
	{
		/// <summary>
		/// Initialized the catalog data
		/// </summary>
		/// <param name="reloading">Is the data being reloaded</param>
		/// <returns>The task apon compleation</returns>
		ValueTask InitializeCatalog(bool reloading = true);

		/// <summary>
		/// Gets all catalog pages
		/// </summary>
		/// <param name="mode">The catalog viewing mode</param>
		/// <returns>A dictionary of catalog pages</returns>
		IDictionary<int, ICatalogPage> GetCatalogPages(string mode);

		/// <summary>
		/// Gets a list of all featured catalog pages (frontpage)
		/// </summary>
		/// <returns>A list of all featured pages</returns>
		IList<ICatalogFeaturedPage> GetFeaturedPages();

		/// <summary>
		/// Tries to get a catalog page
		/// </summary>
		/// <param name="pageId">The page id to recieve</param>
		/// <param name="mode">The catalog viewing mode</param>
		/// <param name="page">The page if found</param>
		/// <returns>True of false if the page was found</returns>
		bool TryGetCatalogPage(int pageId, string mode, out ICatalogPage page);

		/// <summary>
		/// Tries to get a catalog item
		/// </summary>
		/// <param name="itemId">The item id to recieve</param>
		/// <param name="mode">The catalog viewing mode</param>
		/// <param name="item">The item if found</param>
		/// <returns>True of false if the item was found</returns>
		bool TryGetCatalogItem(int itemId, string mode, out ICatalogItem item);

		ICatalogItem GetCatalogItemByOfferId(int offerId);
	}
}