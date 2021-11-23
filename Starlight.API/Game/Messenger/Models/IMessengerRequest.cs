using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.API.Game.Messenger.Models
{
	public interface IMessengerRequest
    {
        /// <summary>
        /// The unique Id associated with the sender.
        /// </summary>
        uint PlayerId { get; }

        /// <summary>
        /// The unique Id associated with the target.
        /// </summary>
        uint TargetId { get; }

        /// <summary>
        /// The username associated with the friend.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The figure of the avatar.
        /// </summary>
        string Figure { get; set; }

        /// <summary>
        /// Compose the assosiated friend request data.
        /// </summary>
        void Compose(IServerMessage message);
    }
}
