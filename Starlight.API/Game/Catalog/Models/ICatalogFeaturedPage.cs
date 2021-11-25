using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Types;

namespace Starlight.API.Game.Catalog.Models
{
    public interface ICatalogFeaturedPage
    {
        int SlotId { get; }
        string Caption { get; }
        string Image { get; }
        FeaturedPageType Type { get; }
        string PageName { get; }
        int PageId { get; }
        string ProductName { get; }
        int ExpireTimestamp { get; }

        void Compose(IServerMessage message);
    }
}
