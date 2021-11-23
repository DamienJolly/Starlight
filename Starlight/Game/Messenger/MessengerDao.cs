using Dapper;
using Starlight.API.Database;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Players.Models;
using System.Collections.Generic;
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

        internal async Task<IList<IMessengerFriend>> GetPlayerFriendsById(uint id)
        {
			using var connection = dbProvider.GetSqlConnection();
			return new List<IMessengerFriend>(await connection.QueryAsync<MessengerFriend>(
				"SELECT `players`.*, `messenger_friends`.* FROM `messenger_friends` INNER JOIN `players` ON `players`.`id` = `messenger_friends`.`target_id` WHERE `messenger_friends`.`player_id` = @playerId",
				new { playerId = id }));
		}

        internal async Task<IList<IMessengerRequest>> GetPlayerRequestsById(uint id)
        {
            using var connection = dbProvider.GetSqlConnection();
            return new List<IMessengerRequest>(await connection.QueryAsync<MessengerRequest>(
                "SELECT `players`.*, `messenger_requests`.* FROM `messenger_requests` INNER JOIN `players` ON `players`.`id` = `messenger_requests`.`target_id` WHERE `messenger_requests`.`player_id` = @playerId",
                new { playerId = id }));
        }

        internal async Task<IList<IMessengerMessage>> GetPlayerMessagesById(uint id)
        {
            using var connection = dbProvider.GetSqlConnection();
            return new List<IMessengerMessage>(await connection.QueryAsync<MessengerMessage>(
                "SELECT * FROM `messenger_offline_messages` WHERE `player_id` = @playerId;" +
                    "DELETE FROM `messenger_offline_messages` WHERE `player_id` = @playerId",
                new { playerId = id }));
        }

        internal async Task<IList<IMessengerCategory>> GetPlayerCategoriesById(uint id)
        {
            using var connection = dbProvider.GetSqlConnection();
            return new List<IMessengerCategory>(await connection.QueryAsync<MessengerCategory>(
                "SELECT * FROM `messenger_categories` WHERE `player_id` = @playerId",
                new { playerId = id }));
        }

        internal async Task<IList<IPlayerData>> GetSearchPlayers(string username)
        {
            using var connection = dbProvider.GetSqlConnection();
            return new List<IPlayerData>(await connection.QueryAsync<PlayerData>(
                "SELECT * FROM `players` WHERE `username` LIKE @username LIMIT 30",
                new { username = "%" + username + "%" }));
        }

        internal async Task AddPlayerFriend(uint playerId, uint targetId)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "INSERT INTO `messenger_friends` (`player_id`, `target_id`) VALUES (@playerId, @targetId);" +
                    "INSERT INTO `messenger_friends` (`player_id`, `target_id`) VALUES (@targetId, @playerId)",
                new { playerId, targetId });
        }

        internal async Task AddPlayerRequest(uint playerId, uint targetId)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "INSERT INTO `messenger_requests` (`player_id`, `target_id`) VALUES (@playerId, @targetId)",
                new { playerId, targetId });
        }

        internal async Task AddPlayerMessage(IMessengerMessage privateMessage)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "INSERT INTO `messenger_offline_messages` (`player_id`, `target_id`, `message`, `timestamp`) VALUES(@playerId, @targetId, @message, @timestamp)",
                new { playerId = privateMessage.PlayerId, targetId = privateMessage.TargetId, message = privateMessage.Message, timestamp = privateMessage.Timestamp });
        }

        internal async Task RemovePlayerFriend(uint playerId, uint targetId)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "DELETE FROM `messenger_friends` WHERE (`target_id` = @targetId AND `player_id` = @playerId) OR (`target_id` = @playerId AND `player_id` = @targetId)",
                new { playerId, targetId });
        }

        internal async Task RemovePlayerRequest(uint playerId, uint targetId)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "DELETE FROM `messenger_requests` WHERE `player_id` = @playerId AND `target_id` = @targetId",
                new { playerId, targetId });
        }

        internal async Task RemoveAllPlayerRequests(uint playerId)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "DELETE FROM `messenger_requests` WHERE `player_id` = @playerId",
                new { playerId });
        }

        internal async Task UpdatePlayerRelation(IMessengerFriend friend)
        {
            using var connection = dbProvider.GetSqlConnection();
            await connection.QueryAsync(
                "UPDATE `messenger_friends` SET `relation` = @relation WHERE `target_id` = @targetId AND `player_id` = @playerId",
                new { playerId = friend.PlayerId, targetId = friend.TargetId, relation = friend.Relation });
        }
    }
}
