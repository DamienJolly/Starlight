using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Entities.Models;
using Starlight.API.Game.Rooms.Models;
using Starlight.Pathfinding.Models;
using System.Collections.Generic;

namespace Starlight.API.Game.Rooms.Entities
{
	public interface IRoomEntity
	{
        int Id { get; set; }
        IRoom Room { get; set; }
        int BodyRotation { get; set; }
        int HeadRotation { get; set; }
        Position Position { get; set; }
        Position NextPosition { get; set; }
        Position GoalPosition { get; set; }
        IList<Position> PathList { get; }
        string Name { get; set; }
        string Figure { get; set; }
        string Gender { get; set; }
        string Motto { get; set; }
        int Score { get; set; }
        bool NeedsUpdate { get; set; }
        bool IsWalking { get; set; }
        IEntityAction Actions { get; set; }

        void Compose(IServerMessage message);
		void Move(int x, int y);
		void StopWalking();
	}
}
