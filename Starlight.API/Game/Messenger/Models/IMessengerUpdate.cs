using Starlight.API.Game.Messenger.Types;

namespace Starlight.API.Game.Messenger.Models
{
	public interface IMessengerUpdate
    {
        /// <summary>
        /// The update type assosiated with the friend
        /// </summary>
        public MessengerUpdateType UpdateType { get; set; }

        /// <summary>
        /// The friend with the player to update.
        /// </summary>
        public IMessengerFriend Friend { get; set; }
    }
}
