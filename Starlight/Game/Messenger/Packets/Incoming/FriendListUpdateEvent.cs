using Starlight.API.Communication.Messages;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Messenger.Packets.Outgoing;
using Starlight.Utils.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Messenger.Packets.Incoming
{
    public class FriendListUpdateEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.FriendListUpdateEvent;

        protected override async ValueTask Execute(ISession session)
        {
            IList<IMessengerCategory> categories = session.Player.MessengerComponent.Categories;
            IList<IMessengerUpdate> updates = session.Player.MessengerComponent.UpdateQueue.Dequeue();

            await session.WriteAndFlushAsync(new FriendListUpdateComposer(categories, updates));
        }
    }
}
