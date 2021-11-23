using MySql.Data.MySqlClient;
using Starlight.API.Config;
using Starlight.API.Database;
using Starlight.Config.Configs;

namespace Starlight.Database
{
    public class DatabaseHandler : IDatabaseHandler
    {
        private readonly string _connectionString;

        public DatabaseHandler(IConfigHandler configHandler)
        {
            DatabaseConfig config = configHandler.Get<DatabaseConfig>("database");
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = config.GetString("user"),
                Server = config.GetString("host"),
                Database = config.GetString("database"),
                Port = (uint)config.GetInt("port"),
                Password = config.GetString("password")
            };
            _connectionString = stringBuilder.ToString();
        }

        public MySqlConnection GetSqlConnection() => new MySqlConnection(_connectionString);
    }
}
