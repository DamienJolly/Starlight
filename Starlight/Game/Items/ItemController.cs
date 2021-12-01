using Microsoft.Extensions.Logging;
using Starlight.API.Game.Items;
using Starlight.API.Game.Items.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Items
{
	internal class ItemController : IItemController
	{
		private readonly ItemDao _itemDao;
		private readonly ILogger<ItemController> _logger;
		private IDictionary<uint, IItemData> _itemDatas;

		public ItemController(ILogger<ItemController> logger, ItemDao itemDao)
		{
			_logger = logger;
			_itemDao = itemDao;
		}

		public async ValueTask InitializeItems(bool reloading)
		{
			_itemDatas = await _itemDao.GetItemData();

			if (reloading)
			{
				_logger.LogInformation("Reloaded {0} item datas", _itemDatas.Count);
			}
			else
			{
				_logger.LogInformation("Loaded {0} item datas", _itemDatas.Count);
			}
		}

		public bool TryGetItemDataById(uint itemId, out IItemData itemData) =>
			_itemDatas.TryGetValue(itemId, out itemData);

		public async Task<IList<IItem>> GetItemsForPlayer(uint playerId) =>
			await _itemDao.GetItemsForPlayer(playerId, _itemDatas);
	}
}