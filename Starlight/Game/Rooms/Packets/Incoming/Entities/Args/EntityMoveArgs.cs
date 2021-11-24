using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Incoming.Entities.Args
{
    public class EntityMoveArgs : IMessageArgs
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public void Parse(IClientMessage message)
        {
            PositionX = message.ReadInt();
            PositionY = message.ReadInt();
        }
    }
}
