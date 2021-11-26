using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Starlight.API.Database;
using Starlight.Database;
using Starlight.Utils.Extensions;

namespace Starlight
{
	public class Program
	{
		private static IHost CreateHost(string[] args)
		{
			var hostBuilder = Host.CreateDefaultBuilder(args);

			hostBuilder.ConfigureServices((context, services) =>
			{
				services.AddSingleton<IDatabaseHandler, DatabaseHandler>();

				services.RegisterDependencies();

				//services.AddTransient<Game>();

				services.AddHostedService<Starlight>();
			});

			hostBuilder.UseConsoleLifetime(options =>
			{
				options.SuppressStatusMessages = true;
			});

			hostBuilder.UseSerilog();

			return hostBuilder.Build();
		}

		private static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();
			Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

			CreateHost(args).Run();
		}
	}
}