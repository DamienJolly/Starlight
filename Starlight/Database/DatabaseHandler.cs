using Dapper;
using MySql.Data.MySqlClient;
using Starlight.API.Config;
using Starlight.API.Database;
using Starlight.Config.Configs;
using System.Collections.Generic;
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

		public MySqlConnection GetSqlConnection() => new(_connectionString);

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

		public async Task<IEnumerable<T>> Query<T>(string query, object param = null)
		{
			using var connection = GetSqlConnection();
			return await connection.QueryAsync<T>(query, param);
		}

		public async Task<T> QueryFirst<T>(string query, object param = null)
		{
			using var connection = GetSqlConnection();
			return await connection.QueryFirstOrDefaultAsync<T>(query, param);
		}

		public async Task Execute(string query, object param = null)
		{
			using var connection = GetSqlConnection();
			await connection.ExecuteAsync(query, param);
		}
	}
}