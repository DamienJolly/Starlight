using Starlight.API.Communication.Messages;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class AuthenticationOkComposer : MessageComposer
    {
        public AuthenticationOkComposer() : base(Headers.AuthenticationOkComposer)
        {

        }
    }
}
