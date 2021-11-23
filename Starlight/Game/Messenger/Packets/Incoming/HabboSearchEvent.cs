using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Incoming.Args;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class HabboSearchEvent : AbstractMessageEvent<SearchArgs>
    {
		public override short Header => Headers.HabboSearchEvent;

        private readonly IMessengerController _messengerController;

        public HabboSearchEvent(IMessengerController messengerController)
        {
            _messengerController = messengerController;
        }

        protected override async Task HandleAsync(ISession session, SearchArgs args)
        {
            string username = args.Username;

            if (string.IsNullOrEmpty(username))
                return;

            IList<IPlayerData> results = await _messengerController.GetSearchPlayersAsync(username);

            IList<IPlayerData> friends = results.Where(data => session.Player.MessengerComponent.HasFriend(data.Id)).ToList();
            IList<IPlayerData> notFriends = results.Where(data => !session.Player.MessengerComponent.HasFriend(data.Id)).ToList();

            await session.WriteAndFlushAsync(new HabboSearchResultComposer(friends, notFriends));
        }
    }
}
