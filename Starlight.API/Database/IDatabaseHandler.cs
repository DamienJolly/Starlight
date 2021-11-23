using MySql.Data.MySqlClient;

namespace Starlight.API.Database
{
	public interface IDatabaseHandler
	{
		/// <summary>
		/// Gets the open connection to the MySQL Server database.
		/// </summary>
		MySqlConnection GetSqlConnection();
	}
}
