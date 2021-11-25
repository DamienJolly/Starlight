using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using Starlight.Game.Messenger.Packets.Outgoing;
using Starlight.Utils;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class SendMsgEvent : AbstractMessageEvent<PrivateMessageArgs>
    {
		public override short Header => Headers.SendMsgEvent;

        private readonly IMessengerController _messengerController;
        private readonly IPlayerController _playerController;

        public SendMsgEvent(IMessengerController messengerController, IPlayerController playerController)
        {
            _messengerController = messengerController;
            _playerController = playerController;
        }

        protected override async ValueTask Execute(ISession session, PrivateMessageArgs args)
        {
            string message = args.Message;

            if (string.IsNullOrWhiteSpace(message)) return;

            if (!session.Player.MessengerComponent.HasFriend(args.TargetId))
            {
                await session.WriteAndFlushAsync(new InstantMessageErrorComposer(InstantMessageErrorComposer.NOT_FRIENDS, args.TargetId));
                return;
            }

            IPlayer targetPlayer = await _playerController.GetPlayerByIdAsync(args.TargetId);
            if (targetPlayer == null)
                return;

            // Todo: player muted

            // Todo: save message to database
            IMessengerMessage privateMessage = NewMessage(targetPlayer.PlayerData.Id, session.Player.PlayerData.Id, message);

            if (targetPlayer.Session != null)
            {
                // Todo: target muted

                await targetPlayer.Session.WriteAndFlushAsync(new NewConsoleMessageComposer(privateMessage));
                return;
            }

            await _messengerController.AddPlayerMessageAsync(privateMessage);
        }

        private IMessengerMessage NewMessage(uint targetId, uint senderId, string message)
        {
            return new MessengerMessage(
                targetId,
                senderId,
                message,
                (int)UnixTimestamp.Now
            );
        }
    }
}
