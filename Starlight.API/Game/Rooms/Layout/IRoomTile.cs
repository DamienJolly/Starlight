using Starlight.API.Game.Rooms.Types;
using Starlight.Pathfinding.Models;

namespace Starlight.API.Game.Rooms.Layout
{
	public interface IRoomTile
	{
        Position Position { get; }
        double TileHeight { get; set; }
        double DefaultHeight { get; }
        double WalkingHeight { get; set; }
        TileState TileState { get; }

        bool IsValidTile(bool finalStep);
    }
}
