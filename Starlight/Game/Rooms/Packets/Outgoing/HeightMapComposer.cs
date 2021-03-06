using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Rooms.Types;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class HeightMapComposer : MessageComposer
    {
        private readonly IRoomModel RoomModel;

        public HeightMapComposer(IRoomModel roomModel) : base(Headers.HeightMapComposer)
        {
            RoomModel = roomModel;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(RoomModel.MapSizeX);
            message.WriteInt(RoomModel.MapSizeX * RoomModel.MapSizeY);

            for (int y = 0; y < RoomModel.MapSizeY; y++)
            {
                for (int x = 0; x < RoomModel.MapSizeX; x++)
                {
                    if (RoomModel.TileStates[x, y] == TileState.OPEN)
                    {
                        message.WriteShort((short)(RoomModel.TileHeights[x, y] * 256));
                    }
                    else
                    {
                        message.WriteShort(-1);
                    }
                }
            }
        }
    }
}
