using Starlight.API.Game.Rooms.Models;

namespace Starlight.Game.Rooms.Models
{
    internal class Room : IRoom
    {
        public IRoomData RoomData { get; }
        public IRoomModel RoomModel { get; }

        internal Room(IRoomData data, IRoomModel model)
        {
            RoomData = data;
            RoomModel = model;

            InitializeComponents();
        }

        private void InitializeComponents()
        {

        }
    }
}
