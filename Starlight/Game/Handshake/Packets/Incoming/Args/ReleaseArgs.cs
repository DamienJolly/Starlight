using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Incoming.Args
{
    public class ReleaseArgs : IMessageArgs
    {
        public string Release { get; private set; }

        public void Parse(IClientMessage message)
        {
            Release = message.ReadString();
        }
    }
}
