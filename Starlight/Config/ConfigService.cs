using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Config;
using Starlight.API.Config.Configs;
using Starlight.Config.Configs;

namespace Starlight.Config
{
	/// <summary>
	/// The config service initializes the required services.
	/// </summary>
	public class ConfigService : IService
	{
		public void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IConfigHandler, ConfigHandler>();

            serviceCollection.AddTransient<AbstractConfig, DatabaseConfig>();
            serviceCollection.AddTransient<AbstractConfig, ServerConfig>();
		}
	}
}
