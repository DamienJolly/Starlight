using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Incoming.Args
{
    public class RoomLoadArgs : IMessageArgs
    {
        public uint RoomId { get; private set; }
        public string Password { get; private set; }

        public void Parse(IClientMessage message)
        {
            RoomId = message.ReadUint();
            Password = message.ReadString();
        }
    }
}
