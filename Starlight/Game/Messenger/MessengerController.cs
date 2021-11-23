using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger
{
    internal class MessengerController : IMessengerController
    {
        private readonly MessengerRepository _messengerRepository;

        public MessengerController(MessengerRepository messengerRepository)
        {
            _messengerRepository = messengerRepository;
        }

        public async Task<IList<IMessengerFriend>> GetPlayerFriendsByIdAsync(uint id) =>
            await _messengerRepository.GetPlayerFriendsById(id);

        public async Task<IList<IMessengerRequest>> GetPlayerRequestsByIdAsync(uint id) =>
            await _messengerRepository.GetPlayerRequestsById(id);

        public async Task<IList<IMessengerMessage>> GetPlayerMessagesByIdAsync(uint playerId) =>
            await _messengerRepository.GetPlayerMessagesById(playerId);

        public async Task<IList<IMessengerCategory>> GetPlayerCategoriesByIdAsync(uint playerId) =>
           await _messengerRepository.GetPlayerCategoriesById(playerId);

        public async Task<IList<IPlayerData>> GetSearchPlayersAsync(string username) =>
            await _messengerRepository.GetSearchPlayers(username);

        public async Task AddPlayerFriendAsync(uint playerId, uint targetId) =>
            await _messengerRepository.AddPlayerFriend(playerId, targetId);

        public async Task AddPlayerRequestAsync(uint playerId, uint targetId) =>
            await _messengerRepository.AddPlayerRequest(playerId, targetId);

        public async Task AddPlayerMessageAsync(IMessengerMessage privateMessage) =>
            await _messengerRepository.AddPlayerMessage(privateMessage);

        public async Task RemovePlayerFriendAsync(uint playerId, uint targetId) =>
            await _messengerRepository.RemovePlayerFriend(playerId, targetId);

        public async Task RemovePlayerRequestAsync(uint playerId, uint targetId) =>
            await _messengerRepository.RemovePlayerRequest(playerId, targetId);

        public async Task RemoveAllPlayerRequestsAsync(uint playerId) =>
            await _messengerRepository.RemoveAllPlayerRequests(playerId);

        public async Task UpdatePlayerRelationAsync(IMessengerFriend friend) =>
            await _messengerRepository.UpdatePlayerRelation(friend);
    }
}
