using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Entities.Models;
using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Entities.Models;
using Starlight.Pathfinding;
using Starlight.Pathfinding.Models;
using Starlight.Pathfinding.Types;
using System.Collections.Generic;

namespace Starlight.Game.Rooms.Entities
{
    public abstract class BaseEntity : IRoomEntity
    {
        public int Id { get; set; }
        public IRoom Room { get; set; }
        public int BodyRotation { get; set; }
        public int HeadRotation { get; set; }
        public Position Position { get; set; }
        public Position NextPosition { get; set; }
        public Position GoalPosition { get; set; }
        public IList<Position> PathList { get; private set; }
        public string Name { get; set; }
        public string Figure { get; set; }
        public string Gender { get; set; }
        public string Motto { get; set; }
        public int Score { get; set; }
        public bool NeedsUpdate { get; set; }
        public bool IsWalking { get; set; }

        public IEntityAction Actions { get; set; }

        protected BaseEntity(int id, Position position, int rotation, IRoom room, string name, string figure, string gender, string motto, int score)
        {
            Id = id;
            Room = room;
            BodyRotation = rotation;
            HeadRotation = rotation;
            Position = position;
            NextPosition = null;
            GoalPosition = null;
            Name = name;
            Figure = figure;
            Gender = gender;
            Motto = motto;
            Score = score;
            NeedsUpdate = false;
            IsWalking = false;

            Actions = new EntityAction();
        }

        public void StopWalking()
        {
            if (!IsWalking)
                return;

            IsWalking = false;
            PathList.Clear();
            NextPosition = null;
            Actions.RemoveStatus("mv");
            NeedsUpdate = true;
        }

        public void Move(int x, int y)
        {
            if (NextPosition != null)
            {
                Position oldPosition = new Position(NextPosition.X, NextPosition.Y, NextPosition.Z);
                Position.X = oldPosition.X;
                Position.Y = oldPosition.Y;
                Position.Z = Room.RoomModel.TileHeights[oldPosition.X, oldPosition.Y];
                NeedsUpdate = true;
            }

            GoalPosition = new Position(x, y);
            IList<Position> pathList = Pathfinder.FindPath((BaseMap)Room.RoomMap, Position, GoalPosition, DiagonalMovement.NO_OBSTACLE, this);

            if (pathList == null)
                return;

            if (pathList.Count > 0)
            {
                PathList = pathList;
                IsWalking = true;
            }
        }

        public abstract void Compose(IServerMessage message);
    }
}
