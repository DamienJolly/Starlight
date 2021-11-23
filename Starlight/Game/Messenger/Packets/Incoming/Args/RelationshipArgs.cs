using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class RelationshipArgs : IMessageArgs
    {
        public uint TargetId { get; private set; }
        public short RelationshipType { get; private set; }

        public void Parse(IClientMessage message)
        {
            TargetId = message.ReadUint();
            RelationshipType = (short)message.ReadInt();

            if (RelationshipType < 0 || RelationshipType > 3)
                RelationshipType = 0;
        }
    }
}
