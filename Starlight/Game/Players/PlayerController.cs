using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Players.Models;
using System.Threading.Tasks;

namespace Starlight.Game.Players
{
    internal class PlayerController : IPlayerController
    {
        private readonly PlayerRepository _playerRepository;

        /// <summary>
        /// The player controller is used to serve data without manipulating.
        /// </summary>
        /// <param name="playerRepostiory">The player repository(singleton)</param>
        public PlayerController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IPlayerData> GetPlayerDataByIdAsync(uint id) =>
            await _playerRepository.GetPlayerDataById(id);

        public async Task<IPlayerData> GetPlayerDataBySsoAsync(string sso) =>
           await _playerRepository.GetPlayerDataBySso(sso);

        public async Task<uint> GetPlayerIdByUsernameAsync(string username) =>
            await _playerRepository.GetPlayerIdByUsername(username);

        public bool TryAddPlayer(IPlayer player) => 
            _playerRepository.TryAddPlayer(player);

        public void RemovePlayer(IPlayer player) => 
            _playerRepository.RemovePlayer(player);

        public bool TryGetPlayer(uint playerId, out IPlayer player) => 
            _playerRepository.TryGetPlayer(playerId, out player);

        public bool TryGetPlayer(string playerName, out IPlayer player) =>
            _playerRepository.TryGetPlayer(playerName, out player);

        public async Task<IPlayer> GetPlayerByIdAsync(uint playerId)
        {
            if (!TryGetPlayer(playerId, out IPlayer player))
            {
                IPlayerData playerData = await GetPlayerDataByIdAsync(playerId);
                if (playerData != null)
                {
                    player = new Player(playerData, null);
                }
            }

            return player;
        }

        public async Task<IPlayerSettings> GetPlayerSettingsByIdAsync(uint id) =>
            await _playerRepository.GetPlayerSettingsById(id);
    }
}
