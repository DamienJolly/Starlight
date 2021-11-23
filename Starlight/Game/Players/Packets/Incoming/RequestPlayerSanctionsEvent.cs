using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
    public class RequestPlayerSanctionsEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.RequestPlayerSanctionsEvent;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new PlayerSanctionsComposer());
        }
    }
}
