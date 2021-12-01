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

		internal async Task<IPlayerData> GetPlayerDataById(uint id) =>
			await dbProvider.QueryFirst<PlayerData>(
				"SELECT * FROM `players` WHERE `id` = @playerId",
				new { playerId = id });

		internal async Task<IPlayerData> GetPlayerDataBySso(string sso) =>
			await dbProvider.QueryFirst<PlayerData>(
				"SELECT * FROM `players` WHERE `auth_ticket` = @ssoTicket",
				new { ssoTicket = sso });

		internal async Task<uint> GetPlayerIdByUsername(string username) =>
			await dbProvider.QueryFirst<uint>(
				"SELECT `id` FROM `players` WHERE `username` = @username",
				new { username });

		internal async Task<IPlayerSettings> GetPlayerSettingsById(uint id) =>
			await dbProvider.QueryFirst<PlayerSettings>(
				"SELECT * FROM `player_settings` WHERE `player_id` = @playerId",
				new { playerId = id });

		internal async Task AddPlayerSettings(uint id) =>
			await dbProvider.Execute(
				"INSERT INTO `player_settings` (`player_id`) VALUES (@playerId)",
				new { playerId = id });
	}
}