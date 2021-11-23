using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Utils;
using System;
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

        private double[,] _floorHeightMap;
        private bool[,] _tileStateMap;

        public double GetHeight(int x, int y) =>
            _floorHeightMap[x, y];

        public bool GetTileState(int x, int y) =>
            _tileStateMap[x, y];

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
            string[] splitHeightMap = HeightMap.Split('\r');
            MapSizeX = splitHeightMap[0].Length;
            MapSizeY = splitHeightMap.Length;
            _floorHeightMap = new double[MapSizeX, MapSizeY];
            _tileStateMap = new bool[MapSizeX, MapSizeY];

            for (int y = 0; y < MapSizeY; y++)
            {
                char[] line = splitHeightMap[y].Replace("\r", "").Replace("\n", "").ToCharArray();

                int x = 0;
                foreach (char square in line)
                {
                    if (x > MapSizeX)
                    {
                        throw new FormatException($"Invalid room model! Model Id: {Id}");
                    }

                    if (square == 'x')
                    {
                        //Square is blocked!
                        _tileStateMap[x, y] = false;
                    }
                    else
                    {
                        _tileStateMap[x, y] = true;
                        _floorHeightMap[x, y] = square.Parse();
                    }

                    x++;
                }
            }

            DoorZ = _floorHeightMap[DoorX, DoorY];
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

                    if (_tileStateMap[x, y])
                    {
                        double Height = _floorHeightMap[x, y];
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
