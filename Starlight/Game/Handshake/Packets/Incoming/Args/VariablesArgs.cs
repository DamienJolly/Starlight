using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Incoming.Args
{
    public class VariablesArgs : IMessageArgs
    {
        public int Error { get; private set; }
        public string SwfsFolder { get; private set; }
        public string ExternalVariablesLink { get; private set; }

        public void Parse(IClientMessage message)
        {
            Error = message.ReadInt();
            SwfsFolder = message.ReadString();
            ExternalVariablesLink = message.ReadString();
        }
    }
}
