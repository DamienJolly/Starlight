using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;
using Starlight.Game.Catalog.Layouts;
using System.Collections.Generic;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class CatalogPageComposer : MessageComposer
    {
        private readonly string Mode;
        private readonly ICatalogPage CatalogPage;
        private readonly IList<ICatalogFeaturedPage> FeaturedPages;

        public CatalogPageComposer(string mode, ICatalogPage catalogPage, IList<ICatalogFeaturedPage> featuredPages) 
            : base(Headers.CatalogPageComposer)
        {
            Mode = mode;
            CatalogPage = catalogPage;
            FeaturedPages = featuredPages;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(CatalogPage.Id);
            message.WriteString(Mode);

            CatalogPage.PageLayout.ComposePageData(message);

            message.WriteInt(CatalogPage.Items.Count);
            foreach (ICatalogItem item in CatalogPage.Items.Values)
            {
                item.Compose(message);
            }

            message.WriteInt(0);
            message.WriteBoolean(false);

            if (CatalogPage.PageLayout is LayoutFrontpage)
            {
                message.WriteInt(FeaturedPages.Count);
                foreach (ICatalogFeaturedPage featuredPage in FeaturedPages)
                {
                    featuredPage.Compose(message);
                }
            }
        }
	}
}
