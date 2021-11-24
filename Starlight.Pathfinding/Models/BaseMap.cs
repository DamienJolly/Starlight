using Starlight.Pathfinding.Types;
using Starlight.Pathfinding.Utils;
using System.Collections.Generic;

namespace Starlight.Pathfinding.Models
{
    public abstract class BaseMap
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }

        public BaseMap(int mapSizeX, int mapSizeY)
        {
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;
        }

        public abstract bool IsWalkableAt(Position p, bool final, params object[] args);

        public List<Position> GetNeighbors(Position p, DiagonalMovement movement, Position end, params object[] args)
        {
            List<Position> neighbors = new List<Position>();
            bool[] hasMovement = { false, false, false, false };

            for (int i = 0; i < PositionUtil.Positions.Length; i++)
            {
                Position pos = p + PositionUtil.Positions[i];

                if (IsWalkableAt(pos, pos == end, args))
                {
                    neighbors.Add(pos);
                    hasMovement[i] = true;
                }
            }

            switch (movement)
            {
                case DiagonalMovement.ALWAYS:
                    foreach (Position option in PositionUtil.DiagonalPositions)
                    {
                        Position pos = p + option;

                        if (IsWalkableAt(pos, pos == end, args))
                            neighbors.Add(pos);
                    }
                    break;

                case DiagonalMovement.ONE_WALKABLE:
                    for (int i = 0; i < PositionUtil.DiagonalPositions.Length; i++)
                    {
                        int num1 = 3 + i;
                        int num2 = 0 + i;

                        if (num1 > 3) num1 -= 4;

                        if (hasMovement[num1] || hasMovement[num2])
                        {
                            Position pos = p + PositionUtil.DiagonalPositions[i];

                            if (IsWalkableAt(pos, pos == end, args))
                                neighbors.Add(pos);
                        }
                    }
                    break;

                case DiagonalMovement.NO_OBSTACLE:
                    for (int i = 0; i < PositionUtil.DiagonalPositions.Length; i++)
                    {
                        int num1 = 3 + i;
                        int num2 = 0 + i;

                        if (num1 > 3) num1 -= 4;

                        if (hasMovement[num1] && hasMovement[num2])
                        {
                            Position pos = p + PositionUtil.DiagonalPositions[i];

                            if (IsWalkableAt(pos, pos == end, args))
                                neighbors.Add(pos);
                        }
                    }
                    break;
            }

            return neighbors;
        }
    }
}
