using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class RequestFriendEvent : AbstractMessageEvent<FriendRequestArgs>
    {
		public override short Header => Headers.RequestFriendEvent;

        private readonly IMessengerController _messengerController;
        private readonly IPlayerController _playerController;

        public RequestFriendEvent(IMessengerController messengerController, IPlayerController playerController)
        {
            _messengerController = messengerController;
            _playerController = playerController;
        }

        protected override async Task HandleAsync(ISession session, FriendRequestArgs args)
        {
            uint targetId = await _playerController.GetPlayerIdByUsernameAsync(args.Username);

            if (session.Player.MessengerComponent.HasFriend(targetId))
                return;

            if (session.Player.MessengerComponent.HasRequest(targetId))
                return;

            //Todo: has friends disabled

            //Todo: reached limit

            IPlayer targetPlayer = await _playerController.GetPlayerByIdAsync(targetId);
            if (targetPlayer == null)
                return;

			IMessengerRequest request = NewRequest(targetPlayer.PlayerData.Id, session.Player.PlayerData);

			if (targetPlayer.Session != null && targetPlayer.MessengerComponent != null)
            {
                targetPlayer.MessengerComponent.AddRequest(request);
                await targetPlayer.Session.WriteAndFlushAsync(new NewFriendRequestComposer(request));
            }

            await _messengerController.AddPlayerRequestAsync(targetPlayer.PlayerData.Id, session.Player.PlayerData.Id);
        }

        private IMessengerRequest NewRequest(uint senderId, IPlayerData playerData)
        {
            return new MessengerRequest(
                senderId,
                playerData.Id,
                playerData.Username,
                playerData.Figure
            );
        }
    }
}
