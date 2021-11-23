using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms
{
    internal class RoomRepository
    {
        private readonly RoomDao _roomDao;
        private readonly IDictionary<uint, IRoom> _rooms;
        private readonly IDictionary<string, IRoomModel> _roomModels;

        public RoomRepository(RoomDao roomDao)
        {
            _roomDao = roomDao;

            _rooms = new Dictionary<uint, IRoom>();
            _roomModels = new Dictionary<string, IRoomModel>();

            LoadRoomModels();
        }

        public async void LoadRoomModels()
        {
            IList<IRoomModel> roomModels = await _roomDao.GetRoomModels();
            foreach (IRoomModel roomModel in roomModels)
            {
                roomModel.InitializeHeightMap();
                _roomModels.Add(roomModel.Id, roomModel);
            }
        }

        internal async Task<IRoomData> GetRoomDataById(uint id) =>
            await _roomDao.GetRoomDataById(id);

        internal async Task<IRoom> LoadRoomById(uint roomId)
        {
            if (!_rooms.TryGetValue(roomId, out IRoom room))
            {
                IRoomData roomData = await GetRoomDataById(roomId);
                if (roomData != null)
                {
                    if (_roomModels.TryGetValue(roomData.ModelName, out IRoomModel model))
                    {
                        room = new Room(roomData, model);
                        _rooms.Add(room.RoomData.Id, room);
                        return room;
                    }
                }
            }

            return room;
        }
    }
}
