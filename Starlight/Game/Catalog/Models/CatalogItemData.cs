using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Items.Models;

namespace Starlight.Game.Catalog.Models
{
	public class CatalogItemData : ICatalogItemData
	{
		public int Id { get; }
		public int Amount { get; }
		public string Extradata { get; }

		public IItemData ItemData { get; set; }

		public CatalogItemData(int id, int amount, IItemData itemData, string extradata)
		{
			Id = id;
			Amount = amount;
			ItemData = itemData;
			Extradata = extradata;
		}
	}
}