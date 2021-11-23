using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class FollowFriendEvent : AbstractMessageEvent<FollowFriendArgs>
    {
		public override short Header => Headers.FollowFriendEvent;

        private readonly IPlayerController _playerController;

        public FollowFriendEvent(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        protected override async Task HandleAsync(ISession session, FollowFriendArgs args)
        {
			//Todo: hiding offline
			if (!_playerController.TryGetPlayer(args.TargetId, out _))
            {
                await session.WriteAndFlushAsync(new FollowFriendFailedComposer(FollowFriendFailedComposer.FRIEND_OFFLINE));
                return;
            }

            IMessengerFriend friend = session.Player.MessengerComponent.GetFriend(args.TargetId);
            if (friend == null)
            {
                await session.WriteAndFlushAsync(new FollowFriendFailedComposer(FollowFriendFailedComposer.NOT_FRIENDS));
                return;
            }

            //Todo: friend in room

            //Todo: friend blocked following

            //Todo: send room forward composer
        }
    }
}
