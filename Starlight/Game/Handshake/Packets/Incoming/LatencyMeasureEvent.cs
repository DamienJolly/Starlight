using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class LatencyMeasureEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.LatencyMeasureEvent;

        protected override Task HandleAsync(ISession session)
        {
            // Todo: Whatever this is used for..
            return Task.CompletedTask;
        }
    }
}
