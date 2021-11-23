using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.API.Game.Messenger.Models
{
	public interface IMessengerMessage
	{
		/// <summary>
		/// The player Id the message is sent from.
		/// </summary>
		uint PlayerId { get; }

		/// <summary>
		/// The target Id the message is sent to.
		/// </summary>
		uint TargetId { get; }

		/// <summary>
		/// The message for to the target.
		/// </summary>
		string Message { get; }

		/// <summary>
		/// The timestamp for when the message was sent.
		/// </summary>
		int Timestamp { get; }

		/// <summary>
		/// Compose the assosiated private message data.
		/// </summary>
		void Compose(IServerMessage message);
	}
}
