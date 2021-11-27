using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
	public class RemoveFriendEvent : AbstractMessageEvent<RemoveArgs>
	{
		public override short Header => Headers.RemoveFriendEvent;

		private readonly IMessengerController _messengerController;
		private readonly IPlayerController _playerController;

		public RemoveFriendEvent(IMessengerController messengerController, IPlayerController playerController)
		{
			_messengerController = messengerController;
			_playerController = playerController;
		}

		protected override async ValueTask Execute(ISession session, RemoveArgs args)
		{
			foreach (uint targetId in args.TargetIds)
			{
				if (!session.Player.MessengerComponent.HasFriend(targetId))
					continue;

				IPlayer targetPlayer = await _playerController.GetPlayerById(targetId);
				if (targetPlayer == null)
					continue;

				RemoveFriend(targetPlayer, session.Player);
				RemoveFriend(session.Player, targetPlayer);

				await _messengerController.RemovePlayerFriend(session.Player.PlayerData.Id, targetPlayer.PlayerData.Id);
			}
		}

		private void RemoveFriend(IPlayer playerOne, IPlayer playerTwo)
		{
			if (playerOne.Session == null || playerOne.MessengerComponent == null)
				return;

			IMessengerFriend friend = playerOne.MessengerComponent.GetFriend(playerTwo.PlayerData.Id);
			if (friend == null)
				return;

			playerOne.MessengerComponent.RemoveFriend(friend.TargetId);
			playerOne.MessengerComponent.QueueUpdate(MessengerUpdateType.RemoveFriend, friend);
			playerOne.MessengerComponent.ForceUpdate();
		}
	}
}