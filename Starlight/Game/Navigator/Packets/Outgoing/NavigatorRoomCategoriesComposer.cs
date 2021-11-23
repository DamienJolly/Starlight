using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorRoomCategoriesComposer : MessageComposer
    {
        private readonly IList<INavigatorCategory> Categories;
        private readonly int PlayerRank;

        public NavigatorRoomCategoriesComposer(IList<INavigatorCategory> categories, int playerRank) : base(Headers.NavigatorRoomCategoriesComposer)
        {
            Categories = categories;
            PlayerRank = playerRank;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Categories.Count);
            foreach(INavigatorCategory category in Categories)
            {
                message.WriteInt(category.SortId);
                message.WriteString(category.PublicName);
                message.WriteBoolean(category.MinRank <= PlayerRank);
                message.WriteBoolean(!category.Enabled);
                message.WriteString(""); // Dunno?
                message.WriteString(""); // Dunno?
                message.WriteBoolean(false);
            }
        }
    }
}
