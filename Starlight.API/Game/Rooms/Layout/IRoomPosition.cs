using Starlight.Pathfinding.Models;

namespace Starlight.API.Game.Rooms.Layout
{
	public class IRoomPosition : Position
	{
		public double Z { get; set; }

		public IRoomPosition(int x, int y, double z) : base(x, y)
		{
			Z = z;
		}
	}
}
