using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class FriendListUpdateComposer : MessageComposer
    {
        private readonly IList<IMessengerCategory> Categories;
        private readonly IList<IMessengerUpdate> Updates;

        public FriendListUpdateComposer(IList<IMessengerCategory> categories, IList<IMessengerUpdate> updates) : base(Headers.FriendListUpdateComposer)
        {
            Categories = categories;
            Updates = updates;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Categories.Count);

            int i = 1;
            foreach (IMessengerCategory category in Categories)
            {
                message.WriteInt(i);
                message.WriteString(category.Name);
                i++;
            }

            message.WriteInt(Updates.Count);
            foreach (IMessengerUpdate update in Updates)
            {
                message.WriteInt((int)update.UpdateType);

                switch (update.UpdateType)
                {
                    case MessengerUpdateType.RemoveFriend:
                        {
                            message.WriteInt(update.Friend.TargetId);
                            break;
                        }
                    case MessengerUpdateType.AddFriend:
                    case MessengerUpdateType.UpdateFriend:
                        {
                            update.Friend.Compose(message);
                            break;
                        }
                }
            }
        }
    }
}

