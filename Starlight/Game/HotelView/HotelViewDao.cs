using Starlight.API.Database;
using Starlight.API.Game.HotelView.Models;
using Starlight.Game.HotelView.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView
{
	internal class HotelViewDao
	{
		private readonly IDatabaseHandler dbProvider;

		public HotelViewDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IList<IHallOfFamer>> GetHallOfFamers() =>
			(await dbProvider.Query<HallOfFamer>(
				"SELECT `id`, `username`, `figure`, `credits` AS `amount` FROM `players` WHERE `rank` < 5 ORDER BY `amount` DESC LIMIT 10"))
			.ToList<IHallOfFamer>();

		internal async Task<IList<IArticle>> GetNewsArticles() =>
			(await dbProvider.Query<Article>(
				"SELECT `id`, `title`, `text`, `caption`, `type`, `link`, `image` FROM `landing_articles` ORDER BY `id` DESC LIMIT 10"))
			.ToList<IArticle>();
	}
}