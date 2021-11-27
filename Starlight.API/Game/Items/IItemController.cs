using System.Threading.Tasks;

namespace Starlight.API.Game.Items
{
	public interface IItemController
	{
		ValueTask InitializeItems(bool reloading = true);
	}
}