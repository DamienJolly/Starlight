namespace Starlight.API.Game.HotelView.Models
{
	public interface IArticle
	{
        /// <summary>
        /// The id associated with the article.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// The article title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The article content.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// The article caption.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// The article type.
        /// </summary>
        int Type { get; set; }

        /// <summary>
        /// The article link (if available).
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// The article image (if available).
        /// </summary>
        string Image { get; set; }
    }
}
