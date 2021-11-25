using Starlight.API.Communication.Messages;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class SendRoomInviteEvent : AbstractMessageEvent<RoomInviteArgs>
    {
		public override short Header => Headers.SendRoomInviteEvent;

        private readonly IPlayerController _playerController;

        public SendRoomInviteEvent(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        protected override async ValueTask Execute(ISession session, RoomInviteArgs args)
        {
            //Todo: player is muted

            string message = args.Message;

            if (string.IsNullOrWhiteSpace(message)) return;

            //Todo: save invite to database

            foreach (uint targetId in args.TargetIds)
            {
                if (!session.Player.MessengerComponent.HasFriend(targetId))
                    continue;

                if (!_playerController.TryGetPlayer(targetId, out IPlayer targetPlayer))
                    continue;

                //Todo: target ignore room invites

                await targetPlayer.Session.WriteAndFlushAsync(new RoomInviteComposer(session.Player.PlayerData.Id, message));
            }
        }
    }
}
