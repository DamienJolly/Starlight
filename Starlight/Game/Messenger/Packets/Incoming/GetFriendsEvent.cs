using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class GetFriendsEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.GetFriendsEvent;

        private readonly IMessengerController _messengerController;

        public GetFriendsEvent(IMessengerController messengerController)
        {
            _messengerController = messengerController;
        }

        protected override async ValueTask Execute(ISession session)
        {
            session.Player.MessengerComponent.Friends = await _messengerController.GetPlayerFriendsByIdAsync(session.Player.PlayerData.Id);

			await session.WriteAndFlushAsync(new FriendsComposer(session.Player.MessengerComponent.Friends));
		}
    }
}
