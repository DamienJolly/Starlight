using Dapper;
using MySql.Data.MySqlClient;
using Starlight.API.Config;
using Starlight.API.Database;
using Starlight.Config.Configs;
using System.Threading.Tasks;

namespace Starlight.Database
{
	public class DatabaseHandler : IDatabaseHandler
	{
		private readonly string _connectionString;

		public DatabaseHandler(IConfigHandler configHandler)
		{
			DatabaseConfig config = configHandler.Get<DatabaseConfig>("database");

			var stringBuilder = new MySqlConnectionStringBuilder
			{
				UserID = config.GetString("user"),
				Server = config.GetString("host"),
				Database = config.GetString("database"),
				Port = (uint)config.GetInt("port"),
				Password = config.GetString("password")
			};

			_connectionString = stringBuilder.ToString();
		}

		public async ValueTask<bool> TestConnection()
		{
			try
			{
				using var connection = GetSqlConnection();

				await connection.QueryAsync("SELECT version()");
			}
			catch (MySqlException)
			{
				return false;
			}

			return true;
		}

		public MySqlConnection GetSqlConnection() => new(_connectionString);
	}
}