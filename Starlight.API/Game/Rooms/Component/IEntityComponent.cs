using Starlight.API.Game.Rooms.Entities;
using System.Collections.Generic;

namespace Starlight.API.Game.Rooms.Component
{
	public interface IEntityComponent
	{
        int NextEntitityId { get; set; }
		IList<IRoomEntity> Entities { get; }

		void AddEntity(IRoomEntity entity);

        void RemoveEntity(IRoomEntity entity);
    }
}
