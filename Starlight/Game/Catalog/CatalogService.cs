using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Catalog.Handlers;
using Starlight.Game.Catalog.Handlers;

namespace Starlight.Game.Catalog
{
	/// <summary>
	/// The catalog service initializes the required services.
	/// </summary>
	public class CatalogService : IService
	{
		public void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<CatalogDao>();
			serviceCollection.AddSingleton<ICatalogController, CatalogController>();

			RegisterPurchaseHandlers(serviceCollection);
		}

		private static void RegisterPurchaseHandlers(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IPurchaseHandler, DefaultPurchaseHandler>();
		}
	}
}