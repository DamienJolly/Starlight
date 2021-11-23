using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class FloorHeightMapComposer : MessageComposer
    {
        private readonly int WallHeight;
        private readonly string Map;

        public FloorHeightMapComposer(int wallHeight, string map) : base(Headers.FloorHeightMapComposer)
        {
            WallHeight = wallHeight;
            Map = map;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteBoolean(false);
            message.WriteInt(WallHeight); //TODO: Wallheight
            message.WriteString(Map);
        }
    }
}
