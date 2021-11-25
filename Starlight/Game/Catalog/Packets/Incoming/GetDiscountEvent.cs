using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Catalog.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Catalog.Packets.Incoming
{
    public class GetDiscountEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.GetDiscountEvent;

        protected override async ValueTask Execute(ISession session)
        {
            await session.WriteAndFlushAsync(new DiscountComposer());
        }
    }
}
