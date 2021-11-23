using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.Messenger
{
	public interface IMessengerController
	{
        /// <summary>
        /// Get friends assosiated with the player.
        /// </summary>
        /// <param name="id">The player id</param>
        /// <returns>A list of all players friends.</returns>
        Task<IList<IMessengerFriend>> GetPlayerFriendsByIdAsync(uint id);

        /// <summary>
        /// Get friend requests assosiated with the player.
        /// </summary>
        /// <param name="id">The player id</param>
        /// <returns>A list of all players friend requests.</returns>
		Task<IList<IMessengerRequest>> GetPlayerRequestsByIdAsync(uint id);

        /// <summary>
        /// Get offline message recieved for the player.
        /// </summary>
        /// <param name="id">The player id</param>
        /// <returns>A list of all offline messages recieved.</returns>
		Task<IList<IMessengerMessage>> GetPlayerMessagesByIdAsync(uint id);

        /// <summary>
        /// Get messenger categories for the player.
        /// </summary>
        /// <param name="id">The player id</param>
        /// <returns>A list of all messenger catagories for the player.</returns>
        Task<IList<IMessengerCategory>> GetPlayerCategoriesByIdAsync(uint playerId);

        /// <summary>
        /// Fetch a list of player data model from the database.
        /// </summary>
        /// <param name="username">The username associated with the player.</param>
        /// <returns>A list of player data upon task completion</returns>
        Task<IList<IPlayerData>> GetSearchPlayersAsync(string username);

        /// <summary>
        /// Adds a friend for the players.
        /// </summary>
        /// <param name="playerId">The sender player id</param>
        /// <param name="targetId">The target pkayer id</param>
        Task AddPlayerFriendAsync(uint playerId, uint targetId);

        /// <summary>
        /// Adds a friend request for the players.
        /// </summary>
        /// <param name="playerId">The sender player id</param>
        /// <param name="targetId">The target pkayer id</param>
        Task AddPlayerRequestAsync(uint playerId, uint targetId);

        /// <summary>
        /// Adds an offline message for the player to recieve when they next login
        /// </summary>
        /// <param name="privateMessage">The message to be added</param>
        Task AddPlayerMessageAsync(IMessengerMessage privateMessage);

        /// <summary>
        /// Removes a friend assosiated with the player
        /// </summary>
        /// <param name="playerId">The player id making the request</param>
        /// <param name="targetId">The target player to be removes</param>
        Task RemovePlayerFriendAsync(uint playerId, uint targetId);

        /// <summary>
        /// Removes a friend request assosiated with the player
        /// </summary>
        /// <param name="playerId">The player id making the request</param>
        /// <param name="targetId">The target player to be removes</param>
        Task RemovePlayerRequestAsync(uint playerId, uint targetId);

        /// <summary>
        /// Removes all friend requests assosiated with the player
        /// </summary>
        /// <param name="playerId">The player id making the request</param>
        Task RemoveAllPlayerRequestsAsync(uint playerId);

        /// <summary>
        /// Updates the relation for the players friend
        /// </summary>
        /// <param name="playerId">The player id making the request</param>
        /// <param name="friend">The friend to be updated</param>
        Task UpdatePlayerRelationAsync(IMessengerFriend friend);
    }
}
