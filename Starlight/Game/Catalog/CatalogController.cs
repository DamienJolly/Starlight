using Microsoft.Extensions.Logging;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
	internal class CatalogController : ICatalogController
	{
		private readonly CatalogDao _catalogDao;
		private readonly ILogger<CatalogController> _logger;
		private IDictionary<int, ICatalogPage> _catalogBCPages;
		private IDictionary<int, ICatalogPage> _catalogPages;
		private IDictionary<int, ICatalogFeaturedPage> _featuredPages;

		public CatalogController(ILogger<CatalogController> logger, CatalogDao catalogDao)
		{
			_logger = logger;
			_catalogDao = catalogDao;
		}

		public async ValueTask InitializeCatalog(bool reloading)
		{
			_catalogPages = await _catalogDao.GetCatalogPages();
			_catalogBCPages = await _catalogDao.GetCatalogBCPages();
			_featuredPages = await _catalogDao.GetCatalogFeaturedPages();

			if (reloading)
			{
				_logger.LogInformation("Reloaded {0} catalog pages", _catalogPages.Count);
			}
			else
			{
				_logger.LogInformation("Loaded {0} catalog pages", _catalogPages.Count);
			}
		}

		public IDictionary<int, ICatalogPage> GetCatalogPages(string mode)
		{
			return mode switch
			{
				"BUILDERS_CLUB" => _catalogBCPages,
				_ => _catalogPages,
			};
		}

		public IList<ICatalogFeaturedPage> GetFeaturedPages() =>
			_featuredPages.Values.ToList();

		public bool TryGetCatalogPage(int pageId, string mode, out ICatalogPage page)
		{
			return mode switch
			{
				"BUILDERS_CLUB" => _catalogBCPages.TryGetValue(pageId, out page),
				_ => _catalogPages.TryGetValue(pageId, out page),
			};
		}
	}
}