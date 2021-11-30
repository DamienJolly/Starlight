using Starlight.API.Game.Catalog.Handlers;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Handlers
{
	public class DefaultPurchaseHandler : IPurchaseHandler
	{
		public string[] Names => new[]
		{
			"default"
		};

		public ValueTask<bool> TryHandlePurchase(ISession session, string extraData, ICatalogItemData catalogItem, int amount)
		{
			for (int k = 0; k < catalogItem.Amount * amount; k++)
			{
				System.Console.WriteLine("Add item: " + k);
			}

			return ValueTask.FromResult(false);
		}
	}
}