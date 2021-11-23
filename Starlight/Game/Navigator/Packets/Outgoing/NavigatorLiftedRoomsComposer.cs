using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorLiftedRoomsComposer : MessageComposer
    {
        public NavigatorLiftedRoomsComposer() : base(Headers.NavigatorLiftedRoomsComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
            // Todo: Lifted rooms
            message.WriteInt(0);
        }
    }
}
