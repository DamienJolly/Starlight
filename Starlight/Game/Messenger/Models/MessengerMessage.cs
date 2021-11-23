using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;
using Starlight.Utils;

namespace Starlight.Game.Messenger.Models
{
    public class MessengerMessage : IMessengerMessage
    {
        public uint PlayerId { get; }
        public uint TargetId { get; }
        public string Message { get; }
        public int Timestamp { get; }

        private MessengerMessage() { }

        public MessengerMessage(uint playerId, uint targetId, string message, int timestamp)
        {
            PlayerId = playerId;
            TargetId = targetId;
            Message = message;
            Timestamp = timestamp;
        }

        public void Compose(IServerMessage message)
        {
            message.WriteInt(TargetId);
            message.WriteString(Message);
            message.WriteInt((int)UnixTimestamp.Now - Timestamp);
            //message.WriteString(""); // Category figure stuff
        }
    }
}
