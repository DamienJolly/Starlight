using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;

namespace Starlight.Game.Messenger.Packets.Outgoing
{
    public class HabboSearchResultComposer : MessageComposer
    {
        private readonly IList<IPlayerData> Friends;
        private readonly IList<IPlayerData> NotFriends;

        public HabboSearchResultComposer(IList<IPlayerData> friends, IList<IPlayerData> notFriends) : base(Headers.HabboSearchResultComposer)
        {
            Friends = friends;
            NotFriends = notFriends;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Friends.Count);
            foreach (IPlayerData playerData in Friends)
            {
                Append(playerData, message);
            }

            message.WriteInt(NotFriends.Count);
            foreach (IPlayerData playerData in NotFriends)
            {
                Append(playerData, message);
            }
        }

        private void Append(IPlayerData playerData, IServerMessage message)
        {
            message.WriteInt(playerData.Id);
            message.WriteString(playerData.Username);
            message.WriteString(playerData.Motto);
            message.WriteBoolean(false); // online
            message.WriteBoolean(false); // Dunno?
            message.WriteString(""); // Dunno?
            message.WriteInt(0); // Dunno?
            message.WriteString(playerData.Figure);
            message.WriteString("01.01.1970 00:00:00"); //LastOnline
        }
    }
}

