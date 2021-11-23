namespace Starlight.API.Game.Navigator.Models
{
    public interface INavigatorCategory
    {
        int SortId { get; set; }
        int MinRank { get; set; }
        string PublicName { get; set; }
        string Identifier { get; set; }
        string View { get; set; }
        string Category { get; set; }
        //CategoryType CategoryType { get; set; }
        bool Enabled { get; set; }
        bool Collapsed { get; set; }
        int Display { get; set; }
    }
}
