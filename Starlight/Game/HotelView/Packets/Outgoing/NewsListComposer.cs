using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;

namespace Starlight.Game.HotelView.Packets.Outgoing
{
    public class NewsListComposer : MessageComposer
    {
        private readonly IList<IArticle> Articles;

        public NewsListComposer(IList<IArticle> articles) : base(Headers.NewsListComposer)
        {
            Articles = articles;
        }

        public override void Compose(IServerMessage packet)
        {
            packet.WriteInt(Articles.Count);

            foreach (IArticle article in Articles)
            {
                packet.WriteInt(article.Id);
                packet.WriteString(article.Title);
                packet.WriteString(article.Text);
                packet.WriteString(article.Caption);
                packet.WriteInt(article.Type);
                packet.WriteString(article.Link);
                packet.WriteString(article.Image);
            }
        }
    }
}
