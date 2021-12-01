using Starlight.API.Database;
using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms
{
	internal class RoomDao
	{
		private readonly IDatabaseHandler dbProvider;

		public RoomDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IList<IRoomModel>> GetRoomModels() =>
			(await dbProvider.Query<RoomModel>(
				"SELECT * FROM `room_models`"))
			.ToList<IRoomModel>();

		internal async Task<IRoomData> GetRoomDataById(uint id) =>
			await dbProvider.QueryFirst<RoomData>(
				"SELECT * FROM `rooms` WHERE `id` = @roomId",
				new { roomId = id });
	}
}