using Starlight.API.Game.Items.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.Items
{
	public interface IItemController
	{
		Task<IList<IItem>> GetItemsForPlayer(uint playerId);

		ValueTask InitializeItems(bool reloading = true);

		bool TryGetItemDataById(uint itemId, out IItemData itemData);
	}
}