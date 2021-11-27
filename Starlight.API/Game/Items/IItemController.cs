using Starlight.API.Game.Items.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Items
{
	public interface IItemController
	{
		ValueTask InitializeItems(bool reloading = true);
		bool TryGetItemDataById(uint itemId, out IItemData itemData);
	}
}