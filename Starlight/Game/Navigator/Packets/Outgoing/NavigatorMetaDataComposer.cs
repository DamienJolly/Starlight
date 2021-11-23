using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorMetaDataComposer : MessageComposer
    {
        public NavigatorMetaDataComposer() : base(Headers.NavigatorMetaDataComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(4);
            message.WriteString("official_view");
            message.WriteInt(0);
            message.WriteString("hotel_view");
            message.WriteInt(0);
            message.WriteString("roomads_view");
            message.WriteInt(0);
            message.WriteString("myworld_view");
            message.WriteInt(0);
        }
    }
}
