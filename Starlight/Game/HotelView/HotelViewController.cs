using Starlight.API.Game.HotelView;
using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView
{
	internal class HotelViewController : IHotelViewController
	{
		private readonly HotelViewDao _hotelViewDao;
		private IList<IHallOfFamer> _hallOfFamers;
		private IList<IArticle> _articles;

		public HotelViewController(HotelViewDao hotelViewDao)
		{
			_hotelViewDao = hotelViewDao;
		}

		public async Task<IList<IHallOfFamer>> GetHallOfFamers()
		{
			if (_hallOfFamers != null) return _hallOfFamers;

			_hallOfFamers = await _hotelViewDao.GetHallOfFamers();
			return _hallOfFamers;
		}

		public async Task<IList<IArticle>> GetNewsArticles()
		{
			if (_articles != null) return _articles;

			_articles = await _hotelViewDao.GetNewsArticles();
			return _articles;
		}
	}
}