using Starlight.Pathfinding.Models;
using Starlight.Pathfinding.Types;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Starlight.Pathfinding
{
    public static class Pathfinder
    {
        public static IList<Position> FindPath(BaseMap map, Position start, Position end, DiagonalMovement movement, params object[] args)
        {
            //Initializes the binary heap and adds the start entry.
            BinaryHeap openHeap = new BinaryHeap();
            openHeap.Add(new HeapNode(start, ManhattanDistance(start, end)));

            float[,] currentCost = new float[map.MapSizeX, map.MapSizeY];
            Position[,] walkedPath = new Position[map.MapSizeX, map.MapSizeY];

            while (openHeap.HasEntry)
            {
                //Gets the lowest cost node from the heap.
                HeapNode curr = openHeap.Get();

                if (curr.Position == end)
                {
                    return BuildPath(start, end, walkedPath);
                }

                float cost = currentCost[curr.Position.X, curr.Position.Y];
                foreach (Position position in map.GetNeighbors(curr.Position, movement, end, args))
                {
                    float newCost = cost + position.Cost;
                    float oldCost = currentCost[position.X, position.Y];
                    if (!(oldCost <= 0) && !(newCost < oldCost))
                        continue;

                    currentCost[position.X, position.Y] = newCost;
                    walkedPath[position.X, position.Y] = curr.Position;

                    float expCost = newCost + ManhattanDistance(position, end);
                    openHeap.Add(new HeapNode(position, expCost));
                }
            }

            //No path was found.
            return null;
        }

        private static List<Position> BuildPath(Position start, Position end, Position[,] walkedPath)
        {
            List<Position> path = new List<Position> { end };
            Position current = end;
            while (!(current == start))
            {
                current = walkedPath[current.X, current.Y];
                path.Add(current);
            }

            path.RemoveAt(path.Count - 1);
            return path;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float ManhattanDistance(Position start, Position end) =>
            Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y);
    }
}
