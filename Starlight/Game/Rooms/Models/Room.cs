using Starlight.API.Communication.Messages;
using Starlight.API.Game.Rooms.Component;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Layout;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Rooms.Components;
using Starlight.Game.Rooms.Entities;
using Starlight.Game.Rooms.Layout;
using Starlight.Pathfinding.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms.Models
{
    internal class Room : IRoom
    {
        public IRoomData RoomData { get; }
        public IRoomModel RoomModel { get; }

        public IRoomMap RoomMap { get; }
        public IEntityComponent Entity { get; }
        public TaskComponent Task { get; }

        internal Room(IRoomData data, IRoomModel model)
        {
            RoomData = data;
            RoomModel = model;

            RoomMap = new RoomMap(this);
            Entity = new EntityComponent(this);
            Task = new TaskComponent(this);

            Task.StartTasks();
        }

        public void AddPlayerEntity(ISession session)
        {
            int entityId = Entity.NextEntitityId++;
            IRoomEntity userEntity = new PlayerEntity(entityId, new Position(RoomModel.DoorX, RoomModel.DoorY, RoomModel.DoorZ), RoomModel.DoorDir, session);
            Entity.AddEntity(userEntity);
            session.Entity = userEntity;
        }

        public async Task SendMessageAsync(MessageComposer packet)
        {
            foreach (IRoomEntity entity in Entity.Entities)
            {
                if (entity is PlayerEntity playerEntity)
                {
                    if (playerEntity.Session != null)
                        await playerEntity.Session.WriteAndFlushAsync(packet);
                }
            }
        }
    }
}
