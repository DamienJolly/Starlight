using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Handshake.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class PongEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.PongEvent;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new PingComposer());
        }
    }
}
