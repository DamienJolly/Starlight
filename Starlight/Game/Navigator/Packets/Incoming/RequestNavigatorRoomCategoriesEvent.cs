using Starlight.API.Communication.Messages;
using Starlight.API.Game.Navigator;
using Starlight.API.Game.Navigator.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Navigator.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Navigator.Packets.Incoming
{
    public class RequestNavigatorRoomCategoriesEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.RequestNavigatorRoomCategoriesEvent;

        private readonly INavigatorController _navigatorController;

        public RequestNavigatorRoomCategoriesEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        protected override async Task HandleAsync(ISession session)
        {
            IList<INavigatorCategory> categories = _navigatorController.TryGetCategoryByView("hotel_view");

            await session.WriteAndFlushAsync(new NavigatorRoomCategoriesComposer(categories, session.Player.PlayerData.Rank));
        }
    }
}