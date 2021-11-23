using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Navigator;

namespace Starlight.Game.Navigator
{
    /// <summary>
    /// The player service initializes the required services.
    /// </summary>
    public class NavigatorService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<NavigatorDao>();
            serviceCollection.AddSingleton<NavigatorRepository>();
            serviceCollection.AddSingleton<INavigatorController, NavigatorController>();
        }
    }
}
