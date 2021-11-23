using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;

namespace Starlight.Game.Messenger.Models
{
    public class MessengerUpdate : IMessengerUpdate
    {
        public MessengerUpdateType UpdateType { get; set; }

        public IMessengerFriend Friend { get; set; }
    }
}
