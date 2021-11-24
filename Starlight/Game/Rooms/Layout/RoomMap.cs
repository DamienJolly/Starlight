using Starlight.API.Game.Rooms.Layout;
using Starlight.API.Game.Rooms.Models;
using Starlight.Pathfinding.Models;

namespace Starlight.Game.Rooms.Layout
{
	public class RoomMap : BaseMap, IRoomMap
    {
        private readonly IRoom _room;
        private readonly IRoomModel _model;

        public IRoomTile[,] Tiles { get; private set; }

        public RoomMap(IRoom room) : base(room.RoomModel.MapSizeX, room.RoomModel.MapSizeY)
        {
            _room = room;
            _model = room.RoomModel;

            GenerateMap();
        }

        public void GenerateMap()
        {
            Tiles = new RoomTile[_model.MapSizeX, _model.MapSizeY];

            for (int y = 0; y < _model.MapSizeY; y++)
            {
                for (int x = 0; x < _model.MapSizeX; x++)
                {
                    Tiles[x, y] = new RoomTile(
                        _room,
                        new Position(x, y),
                        _model.TileHeights[x, y],
                        _model.TileStates[x, y]
                    );
                }
            }
        }

        public override bool IsWalkableAt(Position p, bool final, params object[] args)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= MapSizeX || p.Y >= MapSizeY)
                return false;

            IRoomTile tile = Tiles[p.X, p.Y];
            if (tile == null)
                return false;

            return tile.IsValidTile(final);
        }
	}
}
