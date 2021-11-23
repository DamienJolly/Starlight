using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class SetRelationshipStatusEvent : AbstractMessageEvent<RelationshipArgs>
    {
		public override short Header => Headers.SetRelationshipStatusEvent;

        private readonly IMessengerController _messengerController;

        public SetRelationshipStatusEvent(IMessengerController messengerController)
        {
            _messengerController = messengerController;
        }

        protected override async Task HandleAsync(ISession session, RelationshipArgs args)
        {
            IMessengerFriend friend = session.Player.MessengerComponent.GetFriend(args.TargetId);
            if (friend == null)
                return;

            friend.Relation = args.RelationshipType;

            session.Player.MessengerComponent.QueueUpdate(MessengerUpdateType.UpdateFriend, friend);
            await _messengerController.UpdatePlayerRelationAsync(friend);
        }
    }
}
