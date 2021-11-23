using Starlight.API.Communication.Messages;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomCloseComposer : MessageComposer
    {
        public RoomCloseComposer() : base(Headers.RoomCloseComposer)
        {

        }
    }
}
