using Starlight.API.Game.Rooms.Types;

namespace Starlight.API.Game.Rooms.Models
{
	public interface IRoomModel
	{
		string Id { get; set; }
		string HeightMap { get; set; }
		int DoorX { get; set; }
		int DoorY { get; set; }
		int DoorDir { get; set; }

		string RelativeHeightMap { get; set; }
		int MapSizeX { get; set; }
		int MapSizeY { get; set; }
		double DoorZ { get; set; }
		TileState[,] TileStates { get; set; }
		double[,] TileHeights { get; set; }

		void InitializeHeightMap();
	}
}
