using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Database
{
	public interface IDatabaseHandler
	{
		ValueTask<bool> TestConnection();

		/// <summary>
		/// Gets the open connection to the MySQL Server database.
		/// </summary>
		MySqlConnection GetSqlConnection();

		Task<IEnumerable<T>> Query<T>(string query, object param = null);

		Task<T> QueryFirst<T>(string query, object param = null);

		Task Execute(string query, object param = null);
	}
}