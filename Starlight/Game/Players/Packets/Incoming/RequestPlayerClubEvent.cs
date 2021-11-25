using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
    public class RequestPlayerClubEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.RequestPlayerClubEvent;

        protected override async ValueTask Execute(ISession session)
        {
            await session.WriteAndFlushAsync(new PlayerClubComposer());
        }
    }
}
