using Starlight.API.Game.HotelView.Models;

namespace Starlight.Game.HotelView.Models
{
    internal class Article : IArticle
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Caption { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
