using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

		public Starlight(ILogger<Starlight> logger, INetworkHandler networkHandler)
		{
			_logger = logger;
			_networkHandler = networkHandler;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			ConsoleUtil.ClearConsole();

			//Initialize services

			await _networkHandler.StartServerAsync("Game Server");
			await _networkHandler.StartServerAsync("RCON Server");
		}

		public async Task StopAsync(CancellationToken cancellationToken)
		{
			ConsoleUtil.ClearConsole();

			_logger.LogInformation("Server is shutting down...");
			await _networkHandler.ServerShutdown();
		}
	}
}