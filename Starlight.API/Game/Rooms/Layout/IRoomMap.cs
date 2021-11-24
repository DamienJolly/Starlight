namespace Starlight.API.Game.Rooms.Layout
{
	public interface IRoomMap
	{
		int MapSizeX { get; }
		int MapSizeY { get; }

		void GenerateMap();
	}
}
