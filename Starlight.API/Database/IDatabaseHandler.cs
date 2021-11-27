using MySql.Data.MySqlClient;
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
	}
}