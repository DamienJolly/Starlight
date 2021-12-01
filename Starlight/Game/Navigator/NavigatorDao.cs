using Starlight.API.Database;
using Starlight.API.Game.Navigator.Models;
using Starlight.Game.Navigator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Navigator
{
	internal class NavigatorDao
	{
		private readonly IDatabaseHandler dbProvider;

		public NavigatorDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IDictionary<string, INavigatorCategory>> GetNavigatorCategories() =>
			(await dbProvider.Query<NavigatorCategory>(
				"SELECT * FROM `navigator_categories` ORDER BY `sort_id`"))
			.ToList<INavigatorCategory>()
			.ToDictionary(row => row.Identifier, row => row);
	}
}