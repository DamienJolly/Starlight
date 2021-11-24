using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomEntryInfoComposer : MessageComposer
    {
        private readonly uint RoomId;
        private readonly bool IsOwner;

        public RoomEntryInfoComposer(uint roomId, bool isOwner) : base(Headers.RoomEntryInfoComposer)
        {
            RoomId = roomId;
            IsOwner = isOwner;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(RoomId);
            message.WriteBoolean(IsOwner);
        }
    }
}
