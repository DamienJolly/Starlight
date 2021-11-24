using Starlight.Pathfinding.Models;

namespace Starlight.Pathfinding.Utils
{
    public class PositionUtil
    {
        public static readonly Position[] Positions = new Position[]
        {
            new Position(0, -1),
            new Position(1, 0),
            new Position(0, 1),
            new Position(-1, 0)
        };

        public static readonly Position[] DiagonalPositions = new Position[]
        {
            new Position(-1, -1),
            new Position(1, -1),
            new Position(1, 1),
            new Position(-1, 1)
        };
    }
}
