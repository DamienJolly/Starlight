using Starlight.API.Game.Items.Models;

namespace Starlight.API.Game.Catalog.Models
{
	public interface ICatalogItemData
	{
		int Id { get; }
		int Amount { get; }
		string Extradata { get; }

		IItemData ItemData { get; set; }
	}
}