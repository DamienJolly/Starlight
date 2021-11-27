using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger
{
	internal class MessengerController : IMessengerController
	{
		private readonly MessengerDao _messengerDao;

		public MessengerController(MessengerDao messengerDao)
		{
			_messengerDao = messengerDao;
		}

		public async Task<IList<IMessengerFriend>> GetPlayerFriendsById(uint id) =>
			await _messengerDao.GetPlayerFriendsById(id);

		public async Task<IList<IMessengerRequest>> GetPlayerRequestsById(uint id) =>
			await _messengerDao.GetPlayerRequestsById(id);

		public async Task<IList<IMessengerMessage>> GetPlayerMessagesById(uint playerId) =>
		   await _messengerDao.GetPlayerMessagesById(playerId);

		public async Task<IList<IMessengerCategory>> GetPlayerCategoriesById(uint playerId) =>
		   await _messengerDao.GetPlayerCategoriesById(playerId);

		public async Task<IList<IPlayerData>> GetSearchPlayers(string username) =>
			await _messengerDao.GetSearchPlayers(username);

		public async Task AddPlayerFriend(uint playerId, uint targetId) =>
			await _messengerDao.AddPlayerFriend(playerId, targetId);

		public async Task AddPlayerRequest(uint playerId, uint targetId) =>
			await _messengerDao.AddPlayerRequest(playerId, targetId);

		public async Task AddPlayerMessage(IMessengerMessage privateMessage) =>
			await _messengerDao.AddPlayerMessage(privateMessage);

		public async Task RemovePlayerFriend(uint playerId, uint targetId) =>
			await _messengerDao.RemovePlayerFriend(playerId, targetId);

		public async Task RemovePlayerRequest(uint playerId, uint targetId) =>
			await _messengerDao.RemovePlayerRequest(playerId, targetId);

		public async Task RemoveAllPlayerRequests(uint playerId) =>
			await _messengerDao.RemoveAllPlayerRequests(playerId);

		public async Task UpdatePlayerRelation(IMessengerFriend friend) =>
			await _messengerDao.UpdatePlayerRelation(friend);
	}
}