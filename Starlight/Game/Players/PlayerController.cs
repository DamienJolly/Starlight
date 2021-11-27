using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Players
{
	internal class PlayerController : IPlayerController
	{
		private readonly PlayerDao _playerDao;
		private readonly IDictionary<uint, IPlayer> _players;
		private readonly IDictionary<string, uint> _playerUsernames;

		public PlayerController(PlayerDao playerDao)
		{
			_playerDao = playerDao;

			_players = new Dictionary<uint, IPlayer>();
			_playerUsernames = new Dictionary<string, uint>();
		}

		public async Task<IPlayerData> GetPlayerDataById(uint id) =>
			await _playerDao.GetPlayerDataById(id);

		public async Task<IPlayerData> GetPlayerDataBySso(string sso) =>
			await _playerDao.GetPlayerDataBySso(sso);

		public async Task<IPlayer> GetPlayerById(uint playerId)
		{
			if (!TryGetPlayer(playerId, out IPlayer player))
			{
				IPlayerData playerData = await GetPlayerDataById(playerId);
				if (playerData != null)
				{
					player = new Player(playerData, null);
				}
			}

			return player;
		}

		public async Task<uint> GetPlayerIdByUsername(string username) =>
			await _playerDao.GetPlayerIdByUsername(username);

		public bool TryAddPlayer(IPlayer player)
		{
			if (!_players.TryAdd(player.PlayerData.Id, player))
				return false;

			if (!_playerUsernames.TryAdd(player.PlayerData.Username, player.PlayerData.Id))
			{
				_players.Remove(player.PlayerData.Id);
				return false;
			}

			return true;
		}

		public void RemovePlayer(IPlayer player)
		{
			// todo: Update player

			_players.Remove(player.PlayerData.Id);
			_playerUsernames.Remove(player.PlayerData.Username);
		}

		public bool TryGetPlayer(uint playerId, out IPlayer player) =>
			_players.TryGetValue(playerId, out player);

		public bool TryGetPlayer(string playerName, out IPlayer player)
		{
			player = null;

			if (_playerUsernames.TryGetValue(playerName, out uint playerId))
			{
				return _players.TryGetValue(playerId, out player);
			}

			return false;
		}

		public async Task<IPlayerSettings> GetPlayerSettingsById(uint id)
		{
			IPlayerSettings playerSettings = await _playerDao.GetPlayerSettingsById(id);

			if (playerSettings == null)
			{
				await _playerDao.AddPlayerSettings(id);
				playerSettings = await _playerDao.GetPlayerSettingsById(id);
			}

			return playerSettings;
		}
	}
}