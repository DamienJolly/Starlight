using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class RoomEntryErrorComposer : MessageComposer
    {
        public static int ROOM_ERROR_GUESTROOM_FULL = 1;
        public static int ROOM_ERROR_CANT_ENTER = 2;
        public static int ROOM_ERROR_QUE = 3;
        public static int ROOM_ERROR_BANNED = 4;

        public static string ROOM_NEEDS_VIP = "c";
        public static string EVENT_USERS_ONLY = "e1";
        public static string ROOM_LOCKED = "na";
        public static string TO_MANY_SPECTATORS = "spectator_mode_full";

        private readonly int ErrorCode;
        private readonly string QueueError;

        public RoomEntryErrorComposer(int errorCode) : base(Headers.RoomEntryErrorComposer)
        {
            ErrorCode = errorCode;
            QueueError = "";
        }

        public RoomEntryErrorComposer(int errorCode, string queueError) : base(Headers.RoomEntryErrorComposer)
        {
            ErrorCode = errorCode;
            QueueError = queueError;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(ErrorCode);
            message.WriteString(QueueError);
        }
    }
}
