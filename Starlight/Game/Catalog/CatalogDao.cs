using Dapper;
using Microsoft.Extensions.Logging;
using Starlight.API.Database;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Items;
using Starlight.API.Game.Items.Models;
using Starlight.Game.Catalog.Models;
using Starlight.Game.Catalog.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
	internal class CatalogDao
	{
		private readonly ILogger<CatalogDao> _logger;
		private readonly IDatabaseHandler dbProvider;
		private readonly IItemController _itemController;

		public CatalogDao(ILogger<CatalogDao> logger, IDatabaseHandler _dbProvider, IItemController itemController)
		{
			_logger = logger;
			dbProvider = _dbProvider;
			_itemController = itemController;
		}

		internal async Task<IDictionary<int, ICatalogPage>> GetCatalogPages()
		{
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogPage> catalogPages = new List<ICatalogPage>(await connection.QueryAsync<CatalogPage>(
				"SELECT * FROM `catalog_pages` ORDER BY `order_num` ASC, `caption` ASC"));

			foreach (ICatalogPage catalogPage in catalogPages)
			{
				catalogPage.PageLayout = CatalogLayoutUtility.GetCatalogLayout(catalogPage.Layout, catalogPage);
				catalogPage.Items = new Dictionary<int, ICatalogItem>();
				catalogPage.OfferIds = new List<int>();
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
				catalogPage.Items = new Dictionary<int, ICatalogItem>();
				catalogPage.OfferIds = new List<int>();
			}

			return catalogPages.ToDictionary(row => row.Id, row => row);
		}

		internal async Task<IDictionary<int, ICatalogFeaturedPage>> GetCatalogFeaturedPages()
		{
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogFeaturedPage> featured = new List<ICatalogFeaturedPage>(await connection.QueryAsync<CatalogFeaturedPage>(
				"SELECT * FROM `catalog_featured_pages`"));

			return featured.ToDictionary(row => row.SlotId, row => row);
		}

		internal async Task<int> GetCatalogItems(IDictionary<int, ICatalogPage> catalogPages)
		{
			int itemsCount = 0;
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogItem> catalogItems = new List<ICatalogItem>(await connection.QueryAsync<CatalogItem>(
				"SELECT * FROM `catalog_items` ORDER BY `id` ASC"));

			foreach (ICatalogItem catalogItem in catalogItems)
			{
				catalogItem.Items = new List<ICatalogItemData>();
				LoadCatalogItems(catalogItem);

				if (catalogPages.TryGetValue(catalogItem.PageId, out ICatalogPage catalogPage))
				{
					catalogPage.Items.Add(catalogItem.Id, catalogItem);

					if (catalogItem.OfferId != -1)
					{
						catalogPage.OfferIds.Add(catalogItem.OfferId);
					}
				}

				itemsCount++;
			}

			return itemsCount;
		}

		internal async Task<int> GetCatalogBCItems(IDictionary<int, ICatalogPage> catalogPages)
		{
			int itemsCount = 0;
			using var connection = dbProvider.GetSqlConnection();

			IList<ICatalogItem> catalogItems = new List<ICatalogItem>(await connection.QueryAsync<CatalogItem>(
				"SELECT * FROM `catalog_bc_items` ORDER BY `id` ASC"));

			foreach (ICatalogItem catalogItem in catalogItems)
			{
				catalogItem.Items = new List<ICatalogItemData>();
				LoadCatalogItems(catalogItem);

				if (catalogPages.TryGetValue(catalogItem.PageId, out ICatalogPage catalogPage))
				{
					catalogPage.Items.Add(catalogItem.Id, catalogItem);

					if (catalogItem.OfferId != -1)
					{
						catalogPage.OfferIds.Add(catalogItem.OfferId);
					}
				}

				itemsCount++;
			}

			return itemsCount;
		}

		private void LoadCatalogItems(ICatalogItem catalogItem)
		{
			string itemParts = catalogItem.ItemIds;
			foreach (string itemPart in itemParts.Split(':'))
			{
				try
				{
					string[] data = itemPart.Split('*');

					uint itemId = uint.Parse(data[0]);
					int amount = 1;
					if (data.Length >= 2)
						amount = int.Parse(data[1]);
					string extraData = "";

					if (!_itemController.TryGetItemDataById(itemId, out IItemData itemData))
					{
						_logger.LogError("Failed to load ItemData for [{0}] this item will be skipped.", itemId);
						continue;
					}

					ICatalogItemData catalogItemData = new CatalogItemData((int)itemId, amount, itemData, extraData);
					catalogItem.Items.Add(catalogItemData);
				}
				catch
				{
					_logger.LogError("Failed to parse item_ids for CatalogItem [{0}] this item will be skipped.", catalogItem.Id);
				}
			}
		}
	}
}