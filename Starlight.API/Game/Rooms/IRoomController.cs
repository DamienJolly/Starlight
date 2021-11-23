using Starlight.API.Game.Rooms.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Rooms
{
	public interface IRoomController
	{
		Task<IRoom> LoadRoomByIdAsync(uint id);
		Task<IRoomData> GetRoomDataByIdAsync(uint id);
	}
}
