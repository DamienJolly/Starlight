using Starlight.API.Game.Navigator.Models;

namespace Starlight.Game.Navigator.Models
{
	public class NavigatorCategory : INavigatorCategory
    {
        public int SortId { get; set; }
        public int MinRank { get; set; }
        public string PublicName { get; set; }
        public string Identifier { get; set; }
        public string View { get; set; }
        public string Category { get; set; }
        //public CategoryType CategoryType { get; set; }
        public bool Enabled { get; set; }
        public bool Collapsed { get; set; }
        public int Display { get; set; }
    }
}
