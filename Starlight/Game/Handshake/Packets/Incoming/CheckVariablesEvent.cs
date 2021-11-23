using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Handshake.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class CheckVariablesEvent : AbstractMessageEvent<VariablesArgs>
    {
        public override short Header => Headers.CheckVariablesEvent;

        protected override Task HandleAsync(ISession session, VariablesArgs args)
        {
            // Do something?
            return Task.CompletedTask;
        }
    }
}
