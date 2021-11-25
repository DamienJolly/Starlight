using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;
using System.Linq;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class CatalogPagesListComposer : MessageComposer
    {
        private readonly IPlayer Player;
        private readonly string Mode;
        private readonly IDictionary<int, ICatalogPage> CatalogPages;

        public CatalogPagesListComposer(IPlayer player, string mode, IDictionary<int, ICatalogPage> catalogPages) : base(Headers.CatalogPagesListComposer)
        {
            Player = player;
            Mode = mode;
            CatalogPages = catalogPages;
        }

        public override void Compose(IServerMessage message)
        {
            IList<ICatalogPage> pages = GetCatalogPages(-1);

            message.WriteBoolean(true);
            message.WriteInt(0);
            message.WriteInt(-1);
            message.WriteString("root");
            message.WriteString("");

            message.WriteInt(0);

            message.WriteInt(pages.Count);
            foreach (ICatalogPage page in pages)
            {
                Append(message, page);
            }

            message.WriteBoolean(false);
            message.WriteString(Mode);
        }

        private void Append(IServerMessage message, ICatalogPage catalogPage)
        {
            IList<ICatalogPage> pages = GetCatalogPages(catalogPage.Id);

            message.WriteBoolean(catalogPage.Visible);
            message.WriteInt(catalogPage.Icon);
            message.WriteInt(catalogPage.Enabled ? catalogPage.Id : -1);
            message.WriteString(catalogPage.Name);
            message.WriteString(catalogPage.Caption);

            //Todo: offer ids
            message.WriteInt(0);

            message.WriteInt(pages.Count);
            foreach (ICatalogPage page in pages)
            {
                Append(message, page);
            }
        }


        private IList<ICatalogPage> GetCatalogPages(int pageId) => 
            CatalogPages.Values.Where(page => page.ParentId == pageId && page.Visible && page.Rank <= Player.PlayerData.Rank).ToList();
	}
}
