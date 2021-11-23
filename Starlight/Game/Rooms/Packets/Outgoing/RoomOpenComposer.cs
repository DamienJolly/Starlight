using Starlight.API.Communication.Messages;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomOpenComposer : MessageComposer
    {
        public RoomOpenComposer() : base(Headers.RoomOpenComposer)
        {

        }
    }
}
