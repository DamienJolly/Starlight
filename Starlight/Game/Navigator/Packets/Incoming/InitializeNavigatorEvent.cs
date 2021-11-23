using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Navigator.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Navigator.Packets.Incoming
{
    public class InitializeNavigatorEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.InitializeNavigatorEvent;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new NavigatorMetaDataComposer());
            await session.WriteAndFlushAsync(new NavigatorLiftedRoomsComposer());
            await session.WriteAndFlushAsync(new NavigatorCollapsedCategoriesComposer());
            await session.WriteAndFlushAsync(new NavigatorSavedSearchesComposer());
            await session.WriteAndFlushAsync(new NavigatorSettingsComposer(session.Player.PlayerSettings));
        }
    }
}