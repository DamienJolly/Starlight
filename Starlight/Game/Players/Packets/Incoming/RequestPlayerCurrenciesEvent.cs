using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
    public class RequestPlayerCurrenciesEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.RequestPlayerCurrenciesEvent;

        protected override async ValueTask Execute(ISession session)
        {
            await session.WriteAndFlushAsync(new PlayerCreditsComposer(session.Player.PlayerData.Credits));
            await session.WriteAndFlushAsync(new PlayerPointsComposer());
        }
    }
}
