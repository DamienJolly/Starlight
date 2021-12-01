using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Items.Models;
using Starlight.Game.Items.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Items
{
	internal class ItemDao
	{
		private readonly IDatabaseHandler dbProvider;

		public ItemDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IDictionary<uint, IItemData>> GetItemData()
		{
			using var connection = dbProvider.GetSqlConnection();

			IList<IItemData> itemDatas = new List<IItemData>(await connection.QueryAsync<ItemData>(
				"SELECT * FROM `item_data`"));

			foreach (IItemData itemData in itemDatas)
			{
			}

			return itemDatas.ToDictionary(row => row.Id, row => row);
		}

		internal async Task<IList<IItem>> GetItemsForPlayer(uint playerId, IDictionary<uint, IItemData> itemDatas)
		{
			IList<IItem> playerItems = new List<IItem>();
			using var connection = dbProvider.GetSqlConnection();

			var queryResult = await connection.QueryAsync<Item>(
				"SELECT `items`.*, IFNULL(`players`.`username`, '') AS `player_username` FROM `items` LEFT JOIN `players` ON `players`.`id` = `items`.`player_id` WHERE `items`.`player_id` = @playerId AND `items`.`room_id` = '0' ORDER BY `id` DESC",
				new { playerId });

			foreach (IItem item in queryResult)
			{
				if (!itemDatas.TryGetValue(item.ItemId, out IItemData itemData))
					continue;

				item.ItemData = itemData;
				playerItems.Add(item);
			}

			return playerItems;
		}
	}
}