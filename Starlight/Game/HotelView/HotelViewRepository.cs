using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView
{
    internal class HotelViewRepository
    {
        private readonly HotelViewDao _hotelViewDao;
        private IList<IHallOfFamer> _hallOfFamers;
        private IList<IArticle> _articles;

        public HotelViewRepository(HotelViewDao hotelViewDao)
        {
            _hotelViewDao = hotelViewDao;
        }

        internal async Task<IList<IHallOfFamer>> GetHallOfFamersAsync()
        {
            if (_hallOfFamers != null) return _hallOfFamers;

            _hallOfFamers = await _hotelViewDao.GetHallOfFamers();
            return _hallOfFamers;
        }

        internal async Task<IList<IArticle>> GetNewsArticlesAsync()
        {
            if (_articles != null) return _articles;

            _articles = await _hotelViewDao.GetNewsArticles();
            return _articles;
        }
    }
}
