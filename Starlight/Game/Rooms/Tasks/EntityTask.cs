using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Packets.Outgoing;
using Starlight.Pathfinding.Models;
using Starlight.Tasks;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Starlight.Game.Rooms.Tasks
{
	public class EntityTask : BaseTask
	{
        private readonly IRoom _room;

        public override int Interval => 500;

        public EntityTask(IRoom room)
        {
            _room = room;
        }

        public override void Run(object sender, ElapsedEventArgs e)
        {
            try
            {
                IList<IRoomEntity> entityUpdates = new List<IRoomEntity>();

                foreach (IRoomEntity entity in _room.Entity.Entities)
                {
                    HandleEntity(entity);

                    if (entity.NeedsUpdate)
                    {
                        entity.NeedsUpdate = false;
                        entityUpdates.Add(entity);
                    }
                }

                if (entityUpdates.Count > 0)
                    _room.SendMessageAsync(new EntitiesUpdateComposer(entityUpdates));
            }
            catch (Exception)
			{

            }
        }

        private void HandleEntity(IRoomEntity entity)
        {
            Position position = entity.Position;
            Position goalPosition = entity.GoalPosition;

            if (entity.IsWalking)
            {
                if (entity.NextPosition != null)
                {
                    entity.Position.X = entity.NextPosition.X;
                    entity.Position.Y = entity.NextPosition.Y;
                    //Todo: z
                }

                if (entity.PathList.Count > 0)
                {
                    Position nextPosition = entity.PathList[entity.PathList.Count - 1];
                    entity.PathList.Remove(nextPosition);

                    //Todo: check if tile is now blocked for remap

                    int rotation = Position.CalculateDirection(position, nextPosition);
                    //Todo: height

                    entity.Actions.RemoveStatus("mv");
                    entity.Actions.RemoveStatus("sit");
                    entity.Actions.RemoveStatus("lay");

                    entity.BodyRotation = rotation;
                    entity.HeadRotation = rotation;
                    entity.Actions.AddStatus("mv", string.Format("{0},{1},{2}", nextPosition.X, nextPosition.Y, ""));
                    entity.NextPosition = nextPosition;
                }
                else
                {
                    entity.StopWalking();
                }

                entity.NeedsUpdate = true;
            }
        }
    }
}
