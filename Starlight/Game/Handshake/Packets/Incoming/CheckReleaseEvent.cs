using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Handshake.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class CheckReleaseEvent : AbstractMessageEvent<ReleaseArgs>
    {
		public override short Header => Headers.CheckReleaseEvent;

        protected override Task HandleAsync(ISession session, ReleaseArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
