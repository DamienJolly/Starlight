using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomVisualizationSettingsComposer : MessageComposer
    {
        private readonly bool HideWalls;
        private readonly int WallThickness;
        private readonly int FloorThicknes;

        public RoomVisualizationSettingsComposer(bool hideWalls, int wallThickness, int floorThicknes) : base(Headers.RoomVisualizationSettingsComposer)
        {
            HideWalls = hideWalls;
            WallThickness = wallThickness;
            FloorThicknes = floorThicknes;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteBoolean(HideWalls);
            message.WriteInt(WallThickness);
            message.WriteInt(FloorThicknes);
        }
    }
}
