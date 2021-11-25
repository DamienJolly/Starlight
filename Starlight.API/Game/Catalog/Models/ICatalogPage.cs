using Starlight.API.Game.Catalog.Layouts;

namespace Starlight.API.Game.Catalog.Models
{
    public interface ICatalogPage
    {
        int Id { get; }
        int ParentId { get; }
        string Name { get; }
        string Caption { get; }
        int Icon { get; }
        int Rank { get; }
        string HeaderImage { get; }
        string TeaserImage { get; }
        string SpecialImage { get; }
        string TextOne { get; }
        string TextTwo { get; }
        string TextDetails { get; }
        string TextTeaser { get; }
        string Layout { get; }
        bool Enabled { get; }
        bool Visible { get; }

        CatalogLayout PageLayout { get; set; }
    }
}
