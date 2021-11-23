using Starlight.API.Communication.Messages;
using Starlight.API.Game.Navigator;
using Starlight.API.Game.Navigator.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Navigator.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Navigator.Packets.Incoming
{
    public class RequestNavigatorEventCategoriesEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.RequestNavigatorEventCategoriesEvent;

        private readonly INavigatorController _navigatorController;

        public RequestNavigatorEventCategoriesEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        protected override async Task HandleAsync(ISession session)
        {
            IList<INavigatorCategory> categories = _navigatorController.TryGetCategoryByView("roomads_view");

            await session.WriteAndFlushAsync(new NavigatorEventCategoriesComposer(categories));
        }
    }
}