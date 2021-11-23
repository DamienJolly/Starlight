using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.API.Game.Messenger.Models
{
	public interface IMessengerFriend
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
        /// The gender of the friend.
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// The motto of the friend.
        /// </summary>
        string Motto { get; set; }

        /// <summary>
        /// The relationship type of the friend.
        /// </summary>
        short Relation { get; set; }

        /// <summary>
        /// The category id of the friend.
        /// </summary>
        int Category { get; set; }

        /// <summary>
        /// Compose the assosiated friend data.
        /// </summary>
        void Compose(IServerMessage message);
    }
}
