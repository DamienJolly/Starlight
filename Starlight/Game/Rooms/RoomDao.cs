using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Rooms.Models;
using Starlight.Game.Rooms.Models;
using System.Collections.Generic;
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

        internal async Task<IList<IRoomModel>> GetRoomModels()
        {
            using var connection = dbProvider.GetSqlConnection();
            return new List<IRoomModel>(await connection.QueryAsync<RoomModel>(
                "SELECT * FROM `room_models`"));
        }

        internal async Task<IRoomData> GetRoomDataById(uint id)
        {
            using var connection = dbProvider.GetSqlConnection();
            return await connection.QueryFirstOrDefaultAsync<RoomData>(
                "SELECT * FROM `rooms` WHERE `id` = @roomId",
                new { roomId = id });
        }
    }
}
