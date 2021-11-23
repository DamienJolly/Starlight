using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.HotelView
{
	public interface IHotelViewController
	{
        /// <summary>
        /// Get the top 10 players with highest diamonds.
        /// </summary>
        /// <returns>the top 10 players upon task completion.</returns>
        Task<IList<IHallOfFamer>> GetHallOfFamersAsync();

        /// <summary>
        /// Get the latest 10 news articles.
        /// </summary>
        /// <returns>the latest 10 news articles upon task completion.</returns>
        Task<IList<IArticle>> GetNewsArticlesAsync();
    }
}
