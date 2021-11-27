using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
	public class DeclineFriendEvent : AbstractMessageEvent<DeclineArgs>
	{
		public override short Header => Headers.DeclineFriendEvent;

		private readonly IMessengerController _messengerController;

		public DeclineFriendEvent(IMessengerController messengerController)
		{
			_messengerController = messengerController;
		}

		protected override async ValueTask Execute(ISession session, DeclineArgs args)
		{
			if (args.DeclineAll)
			{
				session.Player.MessengerComponent.RemoveAllRequests();
				await _messengerController.RemoveAllPlayerRequests(session.Player.PlayerData.Id);
				return;
			}

			foreach (uint targetId in args.TargetIds)
			{
				if (!session.Player.MessengerComponent.HasRequest(targetId))
					continue;

				session.Player.MessengerComponent.RemoveRequest(targetId);
				await _messengerController.RemovePlayerRequest(session.Player.PlayerData.Id, targetId);
			}
		}
	}
}