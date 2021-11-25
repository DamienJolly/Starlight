using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;
using Starlight.Game.Catalog.Layouts;

namespace Starlight.Game.Catalog.Utils
{
    public class CatalogLayoutUtility
    {
        public static CatalogLayout GetCatalogLayout(string layout, ICatalogPage catalogPage)
        {
            switch (layout.ToLower())
            {
                default:
                    return new LayoutDefault(catalogPage);

                case "frontpage":
                    return new LayoutFrontpage(catalogPage);
            }
        }
    }
}
