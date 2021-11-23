using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class FollowFriendFailedComposer : MessageComposer
    {
        public static readonly int NOT_FRIENDS = 0; //Reciever is not longer a friend
        public static readonly int FRIEND_OFFLINE = 1; //Reciever is not online
        public static readonly int FRIEND_HOTEL_VIEW = 2; //Reciever is not in a room
        public static readonly int FRIEND_PREVENT = 3; //Reciever has disabled following

        private readonly int ErrorCode;

        public FollowFriendFailedComposer(int errorCode) : base(Headers.FollowFriendFailedComposer)
        {
            ErrorCode = errorCode;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(ErrorCode);
        }
    }
}

