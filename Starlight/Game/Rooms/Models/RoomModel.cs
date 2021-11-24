using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Rooms.Types;
using Starlight.Game.Rooms.Utils;
using System.Text;

namespace Starlight.Game.Rooms.Models
{
	internal class RoomModel : IRoomModel
	{
        public string Id { get; set; }
        public string HeightMap { get; set; }
        public int DoorX { get; set; }
        public int DoorY { get; set; }
        public int DoorDir { get; set; }

        public string RelativeHeightMap { get; set; }
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        public double DoorZ { get; set; }
        public TileState[,] TileStates { get; set; }
        public double[,] TileHeights { get; set; }

        private RoomModel()
        {
            //InitializeHeightMap();
        }

        public void InitializeHeightMap()
        {
            ParseHeightMap();
            ParseRelativeMap();
        }

        private void ParseHeightMap()
        {
            string[] splitHeightMap = HeightMap.Replace("\n", "").Split('\r');

            MapSizeX = splitHeightMap[0].Length;
            MapSizeY = splitHeightMap.Length;

            TileStates = new TileState[MapSizeX, MapSizeY];
            TileHeights = new double[MapSizeX, MapSizeY];

            for (int y = 0; y < MapSizeY; y++)
            {
                char[] line = splitHeightMap[y].ToCharArray();

                for (int x = 0; x < MapSizeX; x++)
                {
                    char square = line[x];

                    if (square != 'x')
                    {
                        TileStates[x, y] = TileState.OPEN;
                        TileHeights[x, y] = square.Parse();
                    }
                    else
                    {
                        TileStates[x, y] = TileState.CLOSED;
                        TileHeights[x, y] = 0;
                    }
                }
            }

            DoorZ = TileHeights[DoorX, DoorY];
        }

        private void ParseRelativeMap()
        {
            StringBuilder relativeMap = new StringBuilder();
            for (int y = 0; y < MapSizeY; y++)
            {
                for (int x = 0; x < MapSizeX; x++)
                {
                    if (x == DoorX && y == DoorY)
                    {
                        relativeMap.Append(DoorZ > 9 ? ((char)(87 + DoorZ)).ToString() : DoorZ.ToString());
                        continue;
                    }

                    if (TileStates[x, y] == TileState.OPEN)
                    {
                        double Height = TileHeights[x, y];
						string Val = Height > 9 ? ((char)(87 + Height)).ToString() : Height.ToString();
                        relativeMap.Append(Val);
                    }
                    else
                    {
                        relativeMap.Append("x");
                        continue;
                    }


                }

                relativeMap.Append((char)13);
            }

            RelativeHeightMap = relativeMap.ToString();
        }
    }
}
