using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class InstantMessageErrorComposer : MessageComposer
    {
        public static readonly int RECIEVER_MUTED = 3; //Reciever is muted
        public static readonly int SENDER_MUTED = 4; //Sender is muted
        public static readonly int RECIEVER_OFFLINE = 5; //Offline Messages? Not used? Idk loool
        public static readonly int NOT_FRIENDS = 6; //Reciever is not longer a friend
        public static readonly int FRIEND_BUSY = 7; //Reciever has messages disabled
        public static readonly int RECIEVER_NO_CHAT = 8; //Reciever needs to take Safety Quiz
        public static readonly int SENDER_NO_CHAT = 9; //Sender needs to take Safety Quiz
        public static readonly int OFFLINE_FAILED = 10; //Reciever has offline messages disabled

        private readonly int ErrorCode;
        private readonly uint TargetId;
        private readonly string Message;

        public InstantMessageErrorComposer(int errorCode, uint targetId, string message = "") : base(Headers.InstantMessageErrorComposer)
        {
            ErrorCode = errorCode;
            TargetId = targetId;
            Message = message;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(ErrorCode);
            message.WriteInt(TargetId);
            message.WriteString(Message);
        }
    }
}

