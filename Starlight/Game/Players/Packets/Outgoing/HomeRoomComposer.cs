using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class HomeRoomComposer : MessageComposer
    {
        private readonly int RoomId;

        public HomeRoomComposer(int roomId) : base(Headers.HomeRoomComposer)
        {
            RoomId = roomId;
        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(RoomId);
            packet.WriteInt(RoomId);
        }
	}
}
