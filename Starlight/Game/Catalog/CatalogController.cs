using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;

namespace Starlight.Game.Catalog
{
    internal class CatalogController : ICatalogController
    {
        private readonly CatalogRepository _catalogRepository;

        public CatalogController(CatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public IDictionary<int, ICatalogPage> GetCatalogPages(string mode) =>
            _catalogRepository.GetCatalogPages(mode);

        public bool TryGetCatalogPage(int pageId, string mode, out ICatalogPage page) =>
            _catalogRepository.TryGetCatalogPage(pageId, mode, out page);

        public IList<ICatalogFeaturedPage> GetFeaturedPages() =>
            _catalogRepository.GetFeaturedPages();
    }
}
