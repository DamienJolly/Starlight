using Starlight.API.Game.Rooms.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Rooms
{
	public interface IRoomController
	{
		ValueTask InitializeRoomModels(bool reloading = true);

		Task<IRoom> LoadRoomById(uint id);

		Task<IRoomData> GetRoomDataById(uint id);
	}
}