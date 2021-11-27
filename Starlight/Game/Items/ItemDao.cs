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
	}
}