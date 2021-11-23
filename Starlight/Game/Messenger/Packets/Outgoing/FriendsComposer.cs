using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Messenger.Models;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class FriendsComposer : MessageComposer
    {
        private readonly IList<IMessengerFriend> Friends;

        public FriendsComposer(IList<IMessengerFriend> friends) : base(Headers.FriendsComposer)
        {
            Friends = friends;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(1); // Pages?
            message.WriteInt(0); // index?
            message.WriteInt(Friends.Count);
            foreach (IMessengerFriend friend in Friends)
            {
                friend.Compose(message);
            }
        }
    }
}

