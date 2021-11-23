using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class MessengerInitComposer : MessageComposer
    {
        private readonly int MaxFriends;
        private readonly int MaxFriendsHC;
        private readonly IList<IMessengerCategory> Categories;

        public MessengerInitComposer(int maxFriends, int maxFriendsHC, IList<IMessengerCategory> categories) : base(Headers.MessengerInitComposer)
        {
            MaxFriends = maxFriends;
            MaxFriendsHC = maxFriendsHC;
            Categories = categories;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(MaxFriends);
            message.WriteInt(0); // Dunno?
            message.WriteInt(MaxFriendsHC);
            message.WriteInt(Categories.Count);

            int i = 1;
            foreach (IMessengerCategory category in Categories)
            {
                message.WriteInt(i);
                message.WriteString(category.Name);
                i++;
            }
        }
    }
}
