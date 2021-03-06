using Microsoft.Extensions.Logging;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Handlers;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog
{
	internal class CatalogController : ICatalogController
	{
		private readonly CatalogDao _catalogDao;
		private readonly ILogger<CatalogController> _logger;

		private readonly IDictionary<string, IPurchaseHandler> _purchaseHandlers;
		private IDictionary<int, ICatalogPage> _catalogBCPages;
		private IDictionary<int, ICatalogPage> _catalogPages;
		private IDictionary<int, ICatalogItem> _catalogItems;
		private IDictionary<int, ICatalogItem> _catalogBCItems;
		private IDictionary<int, ICatalogFeaturedPage> _featuredPages;

		public CatalogController(ILogger<CatalogController> logger, CatalogDao catalogDao, IEnumerable<IPurchaseHandler> purchaseHandlers)
		{
			_logger = logger;
			_catalogDao = catalogDao;
			_purchaseHandlers = new Dictionary<string, IPurchaseHandler>();

			foreach (IPurchaseHandler handler in purchaseHandlers)
			{
				foreach (string name in handler.Names)
				{
					_purchaseHandlers.TryAdd(name, handler);
				}
			}
		}

		public async ValueTask<bool> TryHandlePurchase(ISession session, string extraData, ICatalogItemData catalogItem, int amount)
		{
			if (!_purchaseHandlers.TryGetValue(catalogItem.ItemData.InteractionType, out IPurchaseHandler handler))
			{
				if (!_purchaseHandlers.TryGetValue("default", out handler))
					return false;
			}

			return await handler.TryHandlePurchase(session, extraData, catalogItem, amount);
		}

		public async ValueTask InitializeCatalog(bool reloading)
		{
			_catalogPages = await _catalogDao.GetCatalogPages();
			_catalogItems = await _catalogDao.GetCatalogItems(_catalogPages);

			_catalogBCPages = await _catalogDao.GetCatalogBCPages();
			_catalogBCItems = await _catalogDao.GetCatalogBCItems(_catalogBCPages);

			_featuredPages = await _catalogDao.GetCatalogFeaturedPages();

			if (reloading)
			{
				_logger.LogInformation("Reloaded {0} catalog pages and {1} catalog items", _catalogPages.Count, _catalogItems.Count);
				_logger.LogInformation("Reloaded {0} builders club pages and {1} builders club items", _catalogBCPages.Count, _catalogBCItems.Count);
			}
			else
			{
				_logger.LogInformation("Loaded {0} catalog pages and {1} catalog items", _catalogPages.Count, _catalogItems.Count);
				_logger.LogInformation("Loaded {0} builders club pages and {1} builders club items", _catalogBCPages.Count, _catalogBCItems.Count);
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

		public ICatalogItem GetCatalogItemByOfferId(int offerId) =>
			_catalogItems.Values.Where(data => data.OfferId == offerId).FirstOrDefault();

		public bool TryGetCatalogItem(int itemId, string mode, out ICatalogItem item)
		{
			return mode switch
			{
				"BUILDERS_CLUB" => _catalogBCItems.TryGetValue(itemId, out item),
				_ => _catalogItems.TryGetValue(itemId, out item),
			};
		}
	}
}