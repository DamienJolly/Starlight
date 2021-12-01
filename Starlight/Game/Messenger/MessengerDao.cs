using Starlight.API.Database;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Players.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger
{
	internal class MessengerDao
	{
		private readonly IDatabaseHandler dbProvider;

		public MessengerDao(IDatabaseHandler _dbProvider)
		{
			dbProvider = _dbProvider;
		}

		internal async Task<IList<IMessengerFriend>> GetPlayerFriendsById(uint id) =>
			(await dbProvider.Query<MessengerFriend>(
				"SELECT `players`.*, `messenger_friends`.* FROM `messenger_friends` INNER JOIN `players` ON `players`.`id` = `messenger_friends`.`target_id` WHERE `messenger_friends`.`player_id` = @playerId",
				new { playerId = id }))
			.ToList<IMessengerFriend>();

		internal async Task<IList<IMessengerRequest>> GetPlayerRequestsById(uint id) =>
			(await dbProvider.Query<MessengerRequest>(
				"SELECT `players`.*, `messenger_requests`.* FROM `messenger_requests` INNER JOIN `players` ON `players`.`id` = `messenger_requests`.`target_id` WHERE `messenger_requests`.`player_id` = @playerId",
				new { playerId = id }))
			.ToList<IMessengerRequest>();

		internal async Task<IList<IMessengerMessage>> GetPlayerMessagesById(uint id) =>
			(await dbProvider.Query<MessengerMessage>(
				"SELECT * FROM `messenger_offline_messages` WHERE `player_id` = @playerId;" +
					"DELETE FROM `messenger_offline_messages` WHERE `player_id` = @playerId",
				new { playerId = id }))
			.ToList<IMessengerMessage>();

		internal async Task<IList<IMessengerCategory>> GetPlayerCategoriesById(uint id) =>
			(await dbProvider.Query<MessengerCategory>(
				"SELECT * FROM `messenger_categories` WHERE `player_id` = @playerId",
				new { playerId = id }))
			.ToList<IMessengerCategory>();

		internal async Task<IList<IPlayerData>> GetSearchPlayers(string username) =>
			(await dbProvider.Query<PlayerData>(
				"SELECT * FROM `players` WHERE `username` LIKE @username LIMIT 30",
				new { username = "%" + username + "%" }))
			.ToList<IPlayerData>();

		internal async Task AddPlayerFriend(uint playerId, uint targetId) =>
			await dbProvider.Execute(
				"INSERT INTO `messenger_friends` (`player_id`, `target_id`) VALUES (@playerId, @targetId);" +
					"INSERT INTO `messenger_friends` (`player_id`, `target_id`) VALUES (@targetId, @playerId)",
				new { playerId, targetId });

		internal async Task AddPlayerRequest(uint playerId, uint targetId) =>
			await dbProvider.Execute(
				"INSERT INTO `messenger_requests` (`player_id`, `target_id`) VALUES (@playerId, @targetId)",
				new { playerId, targetId });

		internal async Task AddPlayerMessage(IMessengerMessage privateMessage) =>
			await dbProvider.Execute(
				"INSERT INTO `messenger_offline_messages` (`player_id`, `target_id`, `message`, `timestamp`) VALUES (@playerId, @targetId, @message, @timestamp)",
				new { playerId = privateMessage.PlayerId, targetId = privateMessage.TargetId, message = privateMessage.Message, timestamp = privateMessage.Timestamp });

		internal async Task RemovePlayerFriend(uint playerId, uint targetId) =>
			await dbProvider.Execute(
				"DELETE FROM `messenger_friends` WHERE (`target_id` = @targetId AND `player_id` = @playerId) OR (`target_id` = @playerId AND `player_id` = @targetId)",
				new { playerId, targetId });

		internal async Task RemovePlayerRequest(uint playerId, uint targetId) =>
			await dbProvider.Execute(
				"DELETE FROM `messenger_requests` WHERE `player_id` = @playerId AND `target_id` = @targetId",
				new { playerId, targetId });

		internal async Task RemoveAllPlayerRequests(uint playerId) =>
			await dbProvider.Execute(
				"DELETE FROM `messenger_requests` WHERE `player_id` = @playerId",
				new { playerId });

		internal async Task UpdatePlayerRelation(IMessengerFriend friend) =>
			await dbProvider.Execute(
				"UPDATE `messenger_friends` SET `relation` = @relation WHERE `target_id` = @targetId AND `player_id` = @playerId",
				new { playerId = friend.PlayerId, targetId = friend.TargetId, relation = friend.Relation });
	}
}