using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;

namespace Starlight.Game.Messenger.Models
{
	public class MessengerFriend : IMessengerFriend
    {
        public uint PlayerId { get; set; }
        public uint TargetId { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
        public string Gender { get; set; }
        public string Motto { get; set; }
        public short Relation { get; set; } = 0;
        public int Category { get; set; } = 0;

        public void Compose(IServerMessage message)
        {
            message.WriteInt(TargetId);
            message.WriteString(Username);
            message.WriteInt(Gender.ToLower() == "f" ? 1 : 0);
            message.WriteBoolean(true); // Is online
            message.WriteBoolean(true); // Is in room
            message.WriteString(Figure); // Figure of badge code
            message.WriteInt(Category);
            message.WriteString(Motto); // Motto -> Usless
            message.WriteString(""); // Real name? Why?.. -> Usless
            message.WriteString(""); // Dunno?
            message.WriteBoolean(true); // Offline messages enabled
            message.WriteBoolean(false); // Dunno?
            message.WriteBoolean(false); // Pocket habbo -> Useless
            message.WriteShort(Relation);
        }
    }
}
