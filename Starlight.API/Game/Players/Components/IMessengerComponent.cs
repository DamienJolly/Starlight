using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.Players.Components
{
	public interface IMessengerComponent
	{
		/// <summary>
		/// Gets the friends assosiated with the player
		/// </summary>
		IList<IMessengerFriend> Friends { get; set; }

		/// <summary>
		/// Gets the friend requests assosiated with the player
		/// </summary>
		IList<IMessengerRequest> Requests { get; set; }

		/// <summary>
		/// Gets the messenger catagories assosiated with the player
		/// </summary>
		IList<IMessengerCategory> Categories { get; set; }

		/// <summary>
		/// Gets the update queue assosiated with the players friends
		/// </summary>
		ConcurrentQueue<IMessengerUpdate> UpdateQueue { get; }

		/// <summary>
		/// Adds the friend to the update queue for updating
		/// </summary>
		/// <param name="type">The update type</param>
		/// <param name="friend">The friend to updat</param>
		void QueueUpdate(MessengerUpdateType type, IMessengerFriend friend);

		/// <summary>
		/// Sends the messenger update early
		/// This is usefull for adding/removing friends
		/// </summary>
		Task ForceUpdate();

		/// <summary>
		/// Get a friend assosiated with the player.
		/// </summary>
		/// <param name="playerId">The player id</param>
		/// <returns>The players friend</returns>
		IMessengerFriend GetFriend(uint playerId);

		/// <summary>
		/// Get a friend request assosiated with the player.
		/// </summary>
		/// <param name="playerId">The player id</param>
		/// <returns>The players friend request</returns>
		IMessengerRequest GetRequest(uint playerId);

		/// <summary>
		/// Checks if friend already exists.
		/// </summary>
		/// <param name="playerId">The friend player id</param>
		/// <returns>true or false</returns>
		bool HasFriend(uint playerId);

		/// <summary>
		/// Checks if friend request already exists.
		/// </summary>
		/// <param name="playerId">The friend request player id</param>
		/// <returns>true or false</returns>
		bool HasRequest(uint playerId);

		/// <summary>
		/// Adds the friend to the player messenger component.
		/// </summary>
		/// <param name="friend">The friend to add</param>
		void AddFriend(IMessengerFriend friend);

		/// <summary>
		/// Adds the friend request to the player messenger component.
		/// </summary>
		/// <param name="friend">The friend request to add</param>
		void AddRequest(IMessengerRequest request);

		/// <summary>
		/// Removes a friend from the player messenger component.
		/// </summary>
		/// <param name="playerId">The friend player id</param>
		void RemoveFriend(uint playerId);

		/// <summary>
		/// Removes a friend request from the player messenger component.
		/// </summary>
		/// <param name="playerId">The friend request player id</param>
		void RemoveRequest(uint playerId);

		/// <summary>
		/// Removes all friend requests from the player messenger component.
		/// </summary>
		void RemoveAllRequests();
	}
}
