using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class GetFriendRequestsEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.GetFriendRequestsEvent;

        private readonly IMessengerController _messengerController;

        public GetFriendRequestsEvent(IMessengerController messengerController)
        {
            _messengerController = messengerController;
        }

        protected override async ValueTask Execute(ISession session)
        {
            session.Player.MessengerComponent.Requests = await _messengerController.GetPlayerRequestsByIdAsync(session.Player.PlayerData.Id);

            await session.WriteAndFlushAsync(new FriendRequestsComposer(session.Player.MessengerComponent.Requests));
        }
    }
}
