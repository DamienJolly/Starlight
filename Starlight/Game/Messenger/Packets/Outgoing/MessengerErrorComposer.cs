using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class MessengerErrorComposer : MessageComposer
    {
        public static readonly int FRIEND_LIST_OWN_FULL = 1;
        public static readonly int FRIEND_LIST_TARGET_FULL = 2;
        public static readonly int NOT_ACCEPTING_REQUESTS = 3;
        public static readonly int NOT_FOUND = 4;


        private readonly int ErrorCode;

        public MessengerErrorComposer(int errorCode) : base(Headers.MessengerErrorComposer)
        {
            ErrorCode = errorCode;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(0);
            message.WriteInt(ErrorCode);
        }
    }
}

