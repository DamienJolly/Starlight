using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Incoming.Args
{
    public class ActivityArgs : IMessageArgs
    {
        internal string Type { get; private set; }
        internal string Value { get; private set; }
        internal string Action { get; private set; }

        public void Parse(IClientMessage message)
        {
            Type = message.ReadString();
            Value = message.ReadString();
            Action = message.ReadString();
        }
    }
}
