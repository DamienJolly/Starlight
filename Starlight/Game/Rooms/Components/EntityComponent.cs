
using Starlight.API.Game.Rooms.Component;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Models;
using System.Collections.Generic;
using System.Linq;

namespace Starlight.Game.Rooms.Components
{
	public class EntityComponent : IEntityComponent
    {
		private readonly IRoom _room;
		private readonly IDictionary<int, IRoomEntity> _entities;

		public int NextEntitityId { get; set; } = 0;

		public EntityComponent(IRoom room)
		{
			_room = room;

			_entities = new Dictionary<int, IRoomEntity>();
		}

        public void AddEntity(IRoomEntity entity)
        {
            if (!_entities.ContainsKey(entity.Id))
            {
                _entities.Add(entity.Id, entity);
            }
        }

        public void RemoveEntity(IRoomEntity entity)
        {
            if (_entities.ContainsKey(entity.Id))
            {
                _entities.Remove(entity.Id);
            }
        }

        public IList<IRoomEntity> Entities =>
            _entities.Values.ToList();
    }
}
