using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Starlight.API.Database;
using Starlight.API.Game;
using Starlight.API.Network;
using Starlight.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Starlight
{
	public class Starlight : IHostedService
	{
		public static readonly string VERSION = "v0.1.0";

		private readonly ILogger<Starlight> _logger;
		private readonly IDatabaseHandler _databaseHandler;
		private readonly INetworkHandler _networkHandler;
		private readonly IGameServer _gameServer;

		public Starlight(ILogger<Starlight> logger, IDatabaseHandler databaseHandler, INetworkHandler networkHandler, IGameServer gameServer)
		{
			_logger = logger;
			_databaseHandler = databaseHandler;
			_networkHandler = networkHandler;
			_gameServer = gameServer;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			ConsoleUtil.ClearConsole();

			if (!await _databaseHandler.TestConnection())
			{
				_logger.LogError("Unable to connect to database, check settings and restart. Press any key to quit.");
				Console.ReadKey();

				await StopAsync(cancellationToken);
				return;
			}

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