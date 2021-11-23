using Starlight.API.Game.HotelView;
using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView
{
    internal class HotelViewController : IHotelViewController
    {
        private readonly HotelViewRepository _hotelViewRepository;

        /// <summary>
        /// The hotel view controller is used to serve data without manipulating.
        /// </summary>
        /// <param name="hotelViewRepository">The hotel view repository(singleton)</param>
        public HotelViewController(HotelViewRepository hotelViewRepository)
        {
            _hotelViewRepository = hotelViewRepository;
        }

        public async Task<IList<IHallOfFamer>> GetHallOfFamersAsync() =>
            await _hotelViewRepository.GetHallOfFamersAsync();

        public async Task<IList<IArticle>> GetNewsArticlesAsync() =>
            await _hotelViewRepository.GetNewsArticlesAsync();
    }
}
