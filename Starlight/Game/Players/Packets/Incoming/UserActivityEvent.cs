using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
    public class UserActivityEvent : AbstractMessageEvent<ActivityArgs>
    {
		public override short Header => Headers.UserActivityEvent;

        protected override Task HandleAsync(ISession session, ActivityArgs args)
        {
            //TODO: Progress achievements of something?
            return Task.CompletedTask;
        }
    }
}
