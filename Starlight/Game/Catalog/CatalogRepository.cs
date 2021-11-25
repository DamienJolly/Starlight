using Microsoft.Extensions.Logging;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
    internal class CatalogRepository
    {
        private readonly ILogger<CatalogRepository> _logger;
        private readonly CatalogDao _catalogDao;

        private IDictionary<int, ICatalogPage> _catalogPages;

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
		}

		public IDictionary<int, ICatalogPage> GetCatalogPages(string mode)
		{
			switch (mode)
			{
				case "BUILDERS_CLUB":
					//Todo: builders club pages
					return new Dictionary<int, ICatalogPage>();
				case "NORMAL":
				default:
					return _catalogPages;
			}
		}
	}
}
