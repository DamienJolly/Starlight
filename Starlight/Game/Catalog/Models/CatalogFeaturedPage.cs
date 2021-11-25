using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Catalog.Types;
using Starlight.Utils;

namespace Starlight.Game.Catalog.Models
{
	public class CatalogFeaturedPage : ICatalogFeaturedPage
    {
        public int SlotId { get; }
        public string Caption { get; }
        public string Image { get; }
        public FeaturedPageType Type { get; }
        public string PageName { get; }
        public int PageId { get; }
        public string ProductName { get; }
        public int ExpireTimestamp { get; }

        public void Compose(IServerMessage message)
        {
            message.WriteInt(SlotId);
            message.WriteString(Caption);
            message.WriteString(Image);
            message.WriteInt((int)Type);

            switch (Type)
            {
                default:
                case FeaturedPageType.PAGE_NAME:
                    message.WriteString(PageName);
                    break;

                case FeaturedPageType.PAGE_ID:
                    message.WriteInt(PageId);
                    break;

                case FeaturedPageType.PRODUCT_NAME:
                    message.WriteString(ProductName);
                    break;
            }

            message.WriteInt((int)UnixTimestamp.Now - ExpireTimestamp);
        }
    }
}
