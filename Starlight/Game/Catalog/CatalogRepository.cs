using Microsoft.Extensions.Logging;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
    internal class CatalogRepository
    {
        private readonly ILogger<CatalogRepository> _logger;
        private readonly CatalogDao _catalogDao;

        private IDictionary<int, ICatalogPage> _catalogPages;
        private IDictionary<int, ICatalogPage> _catalogBCPages;
		private IDictionary<int, ICatalogFeaturedPage> _featuredPages;

		public CatalogRepository(ILogger<CatalogRepository> logger, CatalogDao catalogDao)
        {
			_logger = logger;
			_catalogDao = catalogDao;

			InitializeCatalog().Wait();
			_logger.LogInformation("Loaded {0} catalog pages", _catalogPages.Count);
		}

		public async Task InitializeCatalog()
		{
			_catalogPages = await _catalogDao.GetCatalogPages();
			_catalogBCPages = await _catalogDao.GetCatalogBCPages();
			_featuredPages = await _catalogDao.GetCatalogFeaturedPages();
		}

		public IDictionary<int, ICatalogPage> GetCatalogPages(string mode)
		{
			return mode switch
			{
				"BUILDERS_CLUB" => _catalogBCPages,
				_ => _catalogPages,
			};
		}

		public bool TryGetCatalogPage(int pageId, string mode, out ICatalogPage page)
		{
			return mode switch
			{
				"BUILDERS_CLUB" => _catalogBCPages.TryGetValue(pageId, out page),
				_ => _catalogPages.TryGetValue(pageId, out page),
			};
		}

		public IList<ICatalogFeaturedPage> GetFeaturedPages() =>
			_featuredPages.Values.ToList();
	}
}
