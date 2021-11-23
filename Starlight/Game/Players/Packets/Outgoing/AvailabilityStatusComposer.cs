using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class AvailabilityStatusComposer : MessageComposer
    {
        public AvailabilityStatusComposer() : base(Headers.AvailabilityStatusComposer)
        {

        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteBoolean(true);
            packet.WriteBoolean(false);
            packet.WriteBoolean(true);
        }
	}
}
