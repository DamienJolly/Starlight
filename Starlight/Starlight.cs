using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Starlight.API.Game;
using Starlight.API.Network;
using Starlight.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Starlight
{
	public class Starlight : IHostedService
	{
		public static readonly string VERSION = "v0.1.0";

		private readonly ILogger<Starlight> _logger;
		private readonly INetworkHandler _networkHandler;
		private readonly IGameServer _gameServer;

		public Starlight(ILogger<Starlight> logger, INetworkHandler networkHandler, IGameServer gameServer)
		{
			_logger = logger;
			_networkHandler = networkHandler;
			_gameServer = gameServer;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			ConsoleUtil.ClearConsole();

			await _gameServer.StartGameServer();

			await _networkHandler.StartServerAsync("Game Server");
			await _networkHandler.StartServerAsync("RCON Server");
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			ConsoleUtil.ClearConsole();

			_logger.LogInformation("Server is shutting down...");

			await _gameServer.StopGameServer();
			await _networkHandler.ServerShutdown();
		}
	}
}