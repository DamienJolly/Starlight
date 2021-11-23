using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Incoming.Args
{
    public class UniqueIdArgs : IMessageArgs
    {
        public string StoredId { get; private set; }
        public string UniqueId { get; private set; }
        public string Capabilities { get; private set; }

        public void Parse(IClientMessage message)
        {
            StoredId = message.ReadString();
            UniqueId = message.ReadString();
            Capabilities = message.ReadString();
        }
    }
}
