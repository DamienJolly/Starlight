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
    }
}
