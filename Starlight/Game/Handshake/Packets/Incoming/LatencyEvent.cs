using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Handshake.Packets.Incoming.Args;
using Starlight.Game.Handshake.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class LatencyEvent : AbstractMessageEvent<LatencyArgs>
    {
		public override short Header => Headers.LatencyEvent;

        protected override async Task HandleAsync(ISession session, LatencyArgs args)
        {
            await session.WriteAndFlushAsync(new LatencyComposer(args.Id));
        }
    }
}
