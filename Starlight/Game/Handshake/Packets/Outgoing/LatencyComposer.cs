using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Outgoing
{
    public class LatencyComposer : MessageComposer
    {
        private readonly int Id;

        public LatencyComposer(int id) : base(Headers.LatencyComposer)
        {
            Id = id;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Id);
        }
    }
}
