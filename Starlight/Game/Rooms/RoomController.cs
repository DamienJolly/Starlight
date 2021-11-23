using Starlight.API.Game.Rooms;
using Starlight.API.Game.Rooms.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms
{
    internal class RoomController : IRoomController
    {
        private readonly RoomRepository _roomRepository;

        /// <summary>
        /// The room controller is used to serve data without manipulating.
        /// </summary>
        /// <param name="roomRepository">The room repository(singleton)</param>
        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IRoom> LoadRoomByIdAsync(uint id) =>
            await _roomRepository.LoadRoomById(id);

        public async Task<IRoomData> GetRoomDataByIdAsync(uint id) =>
            await _roomRepository.GetRoomDataById(id);
    }
}
