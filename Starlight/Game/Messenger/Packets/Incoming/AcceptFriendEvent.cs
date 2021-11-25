using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class AcceptFriendEvent : AbstractMessageEvent<AcceptFriendArgs>
    {
		public override short Header => Headers.AcceptFriendEvent;

        private readonly IMessengerController _messengerController;
        private readonly IPlayerController _playerController;

        public AcceptFriendEvent(IMessengerController messengerController, IPlayerController playerController)
        {
            _messengerController = messengerController;
            _playerController = playerController;
        }

        protected override async ValueTask Execute(ISession session, AcceptFriendArgs args)
        {
            foreach (uint targetId in args.TargetIds)
            {
                if (!session.Player.MessengerComponent.HasRequest(targetId))
                    continue;

                if (session.Player.MessengerComponent.HasFriend(targetId))
                    continue;

                // Todo: friend limits, with errors?

                session.Player.MessengerComponent.RemoveRequest(targetId);
                await _messengerController.RemovePlayerRequestAsync(session.Player.PlayerData.Id, targetId);

                IPlayer targetPlayer = await _playerController.GetPlayerByIdAsync(targetId);
                if (targetPlayer == null)
                    continue;

                CreateFriend(targetPlayer, session.Player);
                CreateFriend(session.Player, targetPlayer);

                await _messengerController.AddPlayerFriendAsync(session.Player.PlayerData.Id, targetPlayer.PlayerData.Id);
            }
        }

        private void CreateFriend(IPlayer playerOne, IPlayer playerTwo)
        {
            if (playerOne.Session == null || playerOne.MessengerComponent == null)
                return;

			IMessengerFriend friend = new MessengerFriend
            {
                PlayerId = playerOne.PlayerData.Id,
                TargetId = playerTwo.PlayerData.Id,
                Username = playerTwo.PlayerData.Username,
                Figure = playerTwo.PlayerData.Figure,
                Gender = playerTwo.PlayerData.Gender,
                Motto = playerTwo.PlayerData.Motto
            }; 

            playerOne.MessengerComponent.AddFriend(friend);
            playerOne.MessengerComponent.QueueUpdate(MessengerUpdateType.AddFriend, friend);
            playerOne.MessengerComponent.ForceUpdate();
        }
    }
}
