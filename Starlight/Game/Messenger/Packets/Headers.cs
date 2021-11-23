namespace Starlight.Game.Messenger.Packets
{
	internal static class Headers
	{
		// Incoming
		internal const short AcceptFriendEvent = 1879;
		internal const short DeclineFriendEvent = 204;
		//internal const short FindNewFriendsEvent = 0;
		internal const short FollowFriendEvent = 2623;
		internal const short FriendListUpdateEvent = 2887;
		internal const short GetFriendRequestsEvent = 2467;
		internal const short GetFriendsEvent = 1368;
		internal const short HabboSearchEvent = 3483;
		internal const short MessengerInitEvent = 1405;
		internal const short RemoveFriendEvent = 853;
		internal const short RequestFriendEvent = 3779;
		internal const short SendMsgEvent = 2279;
		internal const short SendRoomInviteEvent = 1280;
		internal const short SetRelationshipStatusEvent = 2356;
		//internal const short VisitUserEvent = 0;

		// Outgoing
		//internal const short AcceptFriendResultComposer = 0;
		//internal const short FindFriendsProcessResultComposer = 0;
		internal const short FollowFriendFailedComposer = 2087;
		//internal const short FriendListFragmentMessageComposer = 0;
		internal const short FriendListUpdateComposer = 3018;
		//internal const short FriendNotificationComposer = 0;
		internal const short FriendRequestsComposer = 365;
		internal const short FriendsComposer = 3758;
		internal const short HabboSearchResultComposer = 214;
		internal const short InstantMessageErrorComposer = 3896;
		internal const short MessengerErrorComposer = 2087;
		internal const short MessengerInitComposer = 2871;
		//internal const short MiniMailNewMessageComposer = 0;
		//internal const short MiniMailUnreadCountComposer = 0;
		internal const short NewConsoleMessageComposer = 2664;
		internal const short NewFriendRequestComposer = 2455;
		//internal const short RoomInviteErrorComposer = 0;
		internal const short RoomInviteComposer = 2246;
	}
}
