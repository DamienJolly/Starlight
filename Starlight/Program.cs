using Serilog;
using Starlight.Utils;
using System;
using System.Threading.Tasks;

namespace Starlight
{
    public class Program
	{
        private static Starlight _server;

        private async Task Run()
        {
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            ConsoleUtil.ClearConsole();

            _server = new Starlight();
            await _server.RunAsync();

            await ReadLoopAsync();
        }

        private async Task ReadLoopAsync()
        {
            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await _server.StopAsync();
                }
            }
        }

        public static Task Main() => new Program().Run();
    }
}
