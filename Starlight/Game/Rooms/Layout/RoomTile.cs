using Starlight.API.Game.Rooms.Layout;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Rooms.Types;
using Starlight.Pathfinding.Models;

namespace Starlight.Game.Rooms.Layout
{
	public class RoomTile : IRoomTile
	{
        private readonly IRoom _room;

        public Position Position { get; }
        public double TileHeight { get; set; }
        public double DefaultHeight { get; }
        public double WalkingHeight { get; set; }
        public TileState TileState { get; }

        public RoomTile(IRoom room, Position position, double tileHeight, TileState tileState)
        {
            _room = room;
            Position = position;
            TileHeight = tileHeight;
            DefaultHeight = tileHeight;
            TileState = tileState;
            WalkingHeight = tileHeight;
        }

        public bool IsValidTile(bool finalStep)
        {
            return true;
        }
    }
}
