using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Players.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Players
{
	internal class PlayerDao
	{
		private readonly IDatabaseHandler dbProvider;

		public PlayerDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IPlayerData> GetPlayerDataById(uint id)
		{
			using var connection = dbProvider.GetSqlConnection();

			return await connection.QueryFirstOrDefaultAsync<PlayerData>(
				"SELECT * FROM `players` WHERE `id` = @playerId",
				new { playerId = id });
		}

		internal async Task<IPlayerData> GetPlayerDataBySso(string sso)
		{
			using var connection = dbProvider.GetSqlConnection();

			return await connection.QueryFirstOrDefaultAsync<PlayerData>(
				"SELECT * FROM `players` WHERE `auth_ticket` = @ssoTicket",
				new { ssoTicket = sso });
		}

		internal async Task<uint> GetPlayerIdByUsername(string username)
		{
			using var connection = dbProvider.GetSqlConnection();

			return await connection.QueryFirstOrDefaultAsync<uint>(
				"SELECT `id` FROM `players` WHERE `username` = @username",
				new { username });
		}

		internal async Task<IPlayerSettings> GetPlayerSettingsById(uint id)
		{
			using var connection = dbProvider.GetSqlConnection();

			return await connection.QueryFirstOrDefaultAsync<PlayerSettings>(
				"SELECT * FROM `player_settings` WHERE `player_id` = @playerId",
				new { playerId = id });
		}

		internal async Task AddPlayerSettings(uint id)
		{
			using var connection = dbProvider.GetSqlConnection();

			await connection.QueryAsync(
				"INSERT INTO `player_settings` (`player_id`) VALUES (@playerId)",
				new { playerId = id });
		}
	}
}