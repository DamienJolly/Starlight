using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;

namespace Starlight.Game.Messenger.Models
{
	public class MessengerRequest : IMessengerRequest
    {
        public uint PlayerId { get; }
        public uint TargetId { get; }
        public string Username { get; set; }
        public string Figure { get; set; }

        private MessengerRequest() { }

        public MessengerRequest(uint playerId, uint targetId, string username, string figure)
        {
            PlayerId = playerId;
            TargetId = targetId;
            Username = username;
            Figure = figure;
        }

        public void Compose(IServerMessage message)
        {
            message.WriteInt(TargetId);
            message.WriteString(Username);
            message.WriteString(Figure);
        }
    }
}
