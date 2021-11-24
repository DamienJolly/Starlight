using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomAccessibleComposer : MessageComposer
    {
        private readonly string Username;

        public RoomAccessibleComposer(string username) : base(Headers.RoomAccessibleComposer)
        {
            Username = username;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteString(Username);
        }
    }
}
