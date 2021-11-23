using Microsoft.Extensions.Logging;
using Starlight.API.Network;
using Starlight.API.Network.Servers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Network
{
	public class NetworkHandler : INetworkHandler
	{
		private readonly ILogger<NetworkHandler> _logger;
		private readonly IDictionary<string, AbstractServer> _server;

		public NetworkHandler(ILogger<NetworkHandler> logger, IEnumerable<AbstractServer> servers)
		{
			_logger = logger;
			_server = servers.ToDictionary(server => server.Name);
			InitializeServers();

			_logger.LogInformation("Loaded {0} network servers", _server.Count);
		}

		private void InitializeServers()
		{
			foreach (AbstractServer server in _server.Values)
			{
				server.InitializePipeline();
			}
		}

		public async Task StartServerAsync(string name)
		{
			if (!_server.TryGetValue(name, out AbstractServer server))
				return;

			if (!await server.TryConnectAsync())
			{
				_logger.LogInformation("Failed to listen to {0} on {1}:{2}", server.Name, server.Host, server.Port);
				return;
			}

			_logger.LogInformation("{0} is listening on {1}:{2}", server.Name, server.Host, server.Port);
		}

		public async Task StopServerAsync(string name)
		{
			if (!_server.TryGetValue(name, out AbstractServer server))
				return;

			await server.StopAsync();

			_logger.LogInformation("{0} has been stopped", server.Name);
		}

		public async Task ServerShutdown()
		{
			foreach (AbstractServer server in _server.Values)
			{
				await StopServerAsync(server.Name);
			}
		}
	}
}
