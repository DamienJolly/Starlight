using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Items;

namespace Starlight.Game.Items
{
	/// <summary>
	/// The item service initializes the required services.
	/// </summary>
	public class ItemService : IService
	{
		public void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<ItemDao>();
			serviceCollection.AddSingleton<IItemController, ItemController>();
		}
	}
}