﻿using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Catalog.Models;
using Starlight.Game.Catalog.Models;
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
			return new List<ICatalogPage>(await connection.QueryAsync<CatalogPage>(
				"SELECT * FROM `catalog_pages` ORDER BY `order_num` ASC, `caption` ASC"))
				.ToDictionary(row => row.Id, row => row);
		}
	}
}