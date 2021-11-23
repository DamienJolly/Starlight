using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Network;
using Starlight.API.Network.Servers;
using Starlight.Network.Servers;

namespace Starlight.Network
{
    /// <summary>
    /// The network service initializes the required services.
    /// </summary>
    public class NetworkService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<INetworkHandler, NetworkHandler>();

            serviceCollection.AddTransient<AbstractServer, GameServer>();
            serviceCollection.AddTransient<AbstractServer, RCONServer>();
        }
    }
}
