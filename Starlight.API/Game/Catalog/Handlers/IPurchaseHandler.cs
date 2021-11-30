using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Catalog.Handlers
{
	public interface IPurchaseHandler
	{
		string[] Names { get; }

		ValueTask<bool> TryHandlePurchase(ISession session, string extraData, ICatalogItemData catalogItem, int amount);
	}
}