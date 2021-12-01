using Starlight.API.Game.Players.Components;
using Starlight.API.Game.Session.Models;

namespace Starlight.API.Game.Players.Models
{
    public interface IPlayer
    {
        /// <summary>
        /// The player data associated with the player.
        /// </summary>
        IPlayerData PlayerData { get; }

        /// <summary>
        /// The session associated with the player.
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// The player settings associated with the player.
        /// </summary>
        IPlayerSettings PlayerSettings { get; set; }

        /// <summary>
        /// The messenger component associated with the player.
        /// </summary>
        IMessengerComponent MessengerComponent { get; set; }
		IInventoryComponent InventoryComponent { get; set; }
	}
}
