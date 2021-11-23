using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
    public class RequestPlayerIgnoresEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.RequestPlayerIgnoresEvent;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new IgnoredPlayersComposer());
        }
    }
}
