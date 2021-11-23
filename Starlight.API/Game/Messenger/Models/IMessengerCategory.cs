namespace Starlight.API.Game.Messenger.Models
{
	public interface IMessengerCategory
    {
        /// <summary>
        /// The unique Id associated with the player.
        /// </summary>
        uint PlayerId { get; }

        /// <summary>
        /// The category name.
        /// </summary>
        string Name { get; set; }
    }
}
