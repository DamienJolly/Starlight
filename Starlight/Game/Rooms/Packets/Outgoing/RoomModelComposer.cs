using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Models;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomModelComposer : MessageComposer
    {
        private readonly IRoomData RoomData;

        public RoomModelComposer(IRoomData roomData) : base(Headers.RoomModelComposer)
        {
            RoomData = roomData;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteString(RoomData.ModelName);
            message.WriteInt(RoomData.Id);
        }
    }
}
