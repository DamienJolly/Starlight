using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class MessengerInitEvent : AbstractAsyncMessage
    {
        // Todo: Make these configurable
        private static readonly int MAX_FRIENDS = 100;
        private static readonly int MAX_FRIENDS_HC = 200;

        public override short Header => Headers.MessengerInitEvent;

        private readonly IMessengerController _messengerController;

        public MessengerInitEvent(IMessengerController messengerController)
        {
            _messengerController = messengerController;
        }

        protected override async Task HandleAsync(ISession session)
        {
            session.Player.MessengerComponent.Categories = await _messengerController.GetPlayerCategoriesByIdAsync(session.Player.PlayerData.Id);

            await session.WriteAndFlushAsync(new MessengerInitComposer(MAX_FRIENDS, MAX_FRIENDS_HC, session.Player.MessengerComponent.Categories));

            IList<IMessengerMessage> messages = await _messengerController.GetPlayerMessagesByIdAsync(session.Player.PlayerData.Id);
            foreach (IMessengerMessage message in messages)
            {
                await session.WriteAndFlushAsync(new NewConsoleMessageComposer(message));
            }
        }
    }
}
