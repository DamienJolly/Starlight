using System;

namespace Starlight.Pathfinding.Models
{
    public class Position
    {
        private const float DiagonalCost = 1.4142135623730950488016887242097f;
        private const float LateralCost = 1.0f;

        public int X { get; set; }
        public int Y { get; set; }
        public double Z { get; set; }

        public Position(int x, int y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Position one, Position two)
        {
            if (one is null && two is null)
                return true;

            if (one is Position && two is Position)
                return one.Equals(two);

            return false;
        }

        public static bool operator !=(Position one, Position two)
        {
            if (one is null && !(two is null))
                return true;

            if (!(one is null) && two is null)
                return true;

            if (one is Position && two is Position)
                return !one.Equals(two);

            return false;
        }

        public static Position operator +(Position one, Position two)
        {
            return new Position(one.X + two.X, one.Y + two.Y, one.Z + two.Z);
        }

        public static Position operator -(Position one, Position two)
        {
            return new Position(one.X - two.X, one.Y - two.Y, one.Z - two.Z);
        }

        public Position Copy()
        {
            return new Position(X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var t = obj as Position;

            if (t == null)
                return false;

            if (X == t.X && Y == t.Y)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public float Cost =>
            (X != 0 && Y != 0) ? DiagonalCost : LateralCost;

        public static int CalculateDirection(Position oldPos, Position newPos) =>
            CalculateDirection(oldPos.X, oldPos.Y, newPos.X, newPos.Y);

        public static int CalculateDirection(int x, int y, int x2, int y2)
        {
            int dx = x2 - x;
            int dy = y2 - y;

            double angle = Math.Atan2(dy, dx);
            double octant = Math.Round(8 * angle / (2 * Math.PI)) + 8;

            return ((int)octant + 2) % 8;
        }
    }
}
