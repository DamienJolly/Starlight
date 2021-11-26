using Microsoft.Extensions.DependencyInjection;
using Starlight.API.Network;
using Starlight.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Starlight
{
	public class Starlight
	{
        public static readonly string VERSION = "v0.1.0";

        private readonly IServiceProvider _serviceProvider;
        private readonly INetworkHandler _networkHandler;

        public Starlight()
        {
            _serviceProvider = new ServiceFactory().GetServiceProvider();

            _networkHandler = _serviceProvider.GetService<INetworkHandler>();
        }

        public async Task Run()
        {
            await _networkHandler.StartServerAsync("Game Server");
            await _networkHandler.StartServerAsync("RCON Server");
        }

        public async Task Stop()
        {
            await _networkHandler.ServerShutdown();

            Environment.Exit(0);
        }
    }
}
