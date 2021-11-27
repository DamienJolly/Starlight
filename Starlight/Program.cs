using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Starlight.API.Database;
using Starlight.API.Game;
using Starlight.Database;
using Starlight.Game;
using Starlight.Utils.Extensions;
using System.Threading.Tasks;

namespace Starlight
{
	public class Program
	{
		private static IHostBuilder CreateHostBuilder(string[] args)
		{
			var hostBuilder = Host.CreateDefaultBuilder(args);

			hostBuilder.ConfigureLogging((context, logging) =>
			{
				logging.ClearProviders();
				logging.AddSerilog(dispose: false);
			});

			hostBuilder.ConfigureServices((context, services) =>
			{
				services.AddSingleton<IDatabaseHandler, DatabaseHandler>();
				services.AddSingleton<IGameServer, GameServer>();

				services.RegisterDependencies();

				services.AddHostedService<Starlight>();
			});

			hostBuilder.UseConsoleLifetime(options =>
			{
				options.SuppressStatusMessages = true;
			});

			return hostBuilder;
		}

		private static async Task Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();
			Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

			await CreateHostBuilder(args).Build().RunAsync();
		}
	}
}