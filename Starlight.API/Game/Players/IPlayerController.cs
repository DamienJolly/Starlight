using Starlight.API.Game.Players.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Players
{
	public interface IPlayerController
	{
		/// <summary>
		/// Fetch the player data model from the database.
		/// </summary>
		/// <param name="id">The player id associated with the player.</param>
		/// <returns>The player data upon task completion</returns>
		Task<IPlayerData> GetPlayerDataById(uint id);

		/// <summary>
		/// Fetch the player data model from the database.
		/// </summary>
		/// <param name="sso">The single sign on ticket associated with the player.</param>
		/// <returns>The player data upon task completion</returns>
		Task<IPlayerData> GetPlayerDataBySso(string sso);

		/// <summary>
		/// Fetch the player data model from the database.
		/// </summary>
		/// <param name="username">The username associated with the player.</param>
		/// <returns>The player data upon task completion</returns>
		Task<uint> GetPlayerIdByUsername(string username);

		/// <summary>
		/// Trys to add and store the player to the repository.
		/// </summary>
		/// <param name="player">The player model to be stored.</param>
		/// <returns>The player upon task completion</returns>
		bool TryAddPlayer(IPlayer player);

		/// <summary>
		/// Removes the player from the repository.
		/// </summary>
		/// <param name="player">The player model to be removed.</param>
		void RemovePlayer(IPlayer player);

		/// <summary>
		/// Trys to fetch the player from the repository.
		/// </summary>
		/// <param name="playerId">The id associated with the player.</param>
		/// <returns>The player upon completion</returns>
		bool TryGetPlayer(uint playerId, out IPlayer player);

		/// <summary>
		/// Trys to fetch the player from the repository.
		/// </summary>
		/// <param name="playerName">The player name associated with the player.</param>
		/// <returns>The player upon completion</returns>
		bool TryGetPlayer(string playerName, out IPlayer player);

		/// <summary>
		/// Gets a player even if they're not in the repository.
		/// </summary>
		/// <param name="playerId">The id associated with the player.</param>
		/// <returns>The player upon completion</returns>
		Task<IPlayer> GetPlayerById(uint playerId);

		/// <summary>
		/// Get the player settings by player id.
		/// </summary>
		/// <param name="id">The players id.</param>
		/// <returns>The player settings upon task completion.</returns>
		Task<IPlayerSettings> GetPlayerSettingsById(uint id);
	}
}