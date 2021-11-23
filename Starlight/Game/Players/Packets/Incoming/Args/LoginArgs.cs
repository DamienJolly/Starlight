using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Incoming.Args
{
    public class LoginArgs : IMessageArgs
    {
        internal string AuthTicket { get; private set; }

        public void Parse(IClientMessage message)
        {
            AuthTicket = message.ReadString();
        }
    }
}
