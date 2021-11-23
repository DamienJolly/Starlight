using Starlight.API.Communication.Messages;

namespace Starlight.Game.Handshake.Packets.Outgoing
{
    public class PingComposer : MessageComposer
    {
        public PingComposer() : base(Headers.PingComposer)
        {

        }
    }
}
