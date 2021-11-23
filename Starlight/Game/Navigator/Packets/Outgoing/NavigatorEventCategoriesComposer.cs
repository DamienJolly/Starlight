using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorEventCategoriesComposer : MessageComposer
    {
        private readonly IList<INavigatorCategory> Categories;

        public NavigatorEventCategoriesComposer(IList<INavigatorCategory> categories) : base(Headers.NavigatorEventCategoriesComposer)
        {
            Categories = categories;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Categories.Count);
            foreach (INavigatorCategory category in Categories)
            {
                message.WriteInt(category.SortId);
                message.WriteString(category.PublicName);
                message.WriteBoolean(category.Enabled);
            }
        }
    }
}
