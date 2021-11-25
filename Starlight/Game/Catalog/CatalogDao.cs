using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Catalog.Models;
using Starlight.Game.Catalog.Models;
using Starlight.Game.Catalog.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
    internal class CatalogDao
    {
        private readonly IDatabaseHandler dbProvider;

        public CatalogDao(IDatabaseHandler _dbProvider)
        {
            dbProvider = _dbProvider;
        }

		internal async Task<IDictionary<int, ICatalogPage>> GetCatalogPages()
		{
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogPage> catalogPages = new List<ICatalogPage>(await connection.QueryAsync<CatalogPage>(
				"SELECT * FROM `catalog_pages` ORDER BY `order_num` ASC, `caption` ASC"));

			foreach (ICatalogPage catalogPage in catalogPages)
			{
				catalogPage.PageLayout = CatalogLayoutUtility.GetCatalogLayout(catalogPage.Layout, catalogPage);
			}

			return catalogPages.ToDictionary(row => row.Id, row => row);
		}

		internal async Task<IDictionary<int, ICatalogPage>> GetCatalogBCPages()
		{
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogPage> catalogPages = new List<ICatalogPage>(await connection.QueryAsync<CatalogPage>(
				"SELECT * FROM `catalog_bc_pages` ORDER BY `order_num` ASC, `caption` ASC"));

			foreach (ICatalogPage catalogPage in catalogPages)
			{
				catalogPage.PageLayout = CatalogLayoutUtility.GetCatalogLayout(catalogPage.Layout, catalogPage);
			}

			return catalogPages.ToDictionary(row => row.Id, row => row);
		}
	}
}
