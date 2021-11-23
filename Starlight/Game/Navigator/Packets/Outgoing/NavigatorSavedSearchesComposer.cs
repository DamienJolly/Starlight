using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorSavedSearchesComposer : MessageComposer
    {
        public NavigatorSavedSearchesComposer() : base(Headers.NavigatorSavedSearchesComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(0); // Count
            {
                //message.WriteInt(0); // Id
                //message.WriteString(""); // Search code
                //message.WriteString(""); // Filter
                //message.WriteString(""); // Dunno?
            }
        }
    }
}
