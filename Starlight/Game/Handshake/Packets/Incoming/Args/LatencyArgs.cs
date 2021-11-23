using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Incoming.Args
{
    public class LatencyArgs : IMessageArgs
    {
        public int Id { get; private set; }

        public void Parse(IClientMessage message)
        {
            Id = message.ReadInt();
        }
    }
}
