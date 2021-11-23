using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class RoomInviteArgs : IMessageArgs
    {
        public IList<uint> TargetIds { get; private set; }
        public string Message { get; private set; }

        public RoomInviteArgs()
        {
            TargetIds = new List<uint>();
        }

        public void Parse(IClientMessage message)
        {
            int count = message.ReadInt();
            for (int i = 0; i < count; i++)
            {
                TargetIds.Add(message.ReadUint());
            }

            Message = message.ReadString();

            if (Message.Length > 200)
                Message = Message.Substring(0, 200);
        }
    }
}
