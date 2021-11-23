using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class PrivateMessageArgs : IMessageArgs
    {
        public uint TargetId { get; private set; }
        public string Message { get; private set; }

        public void Parse(IClientMessage message)
        {
            TargetId = message.ReadUint();
            Message = message.ReadString();

            if (Message.Length > 200)
                Message = Message.Substring(0, 200);
        }
    }
}
