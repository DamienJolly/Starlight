using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.GameCenter.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.GameCenter.Packets.Incoming
{
    public class GameCenterRequestGamesEvent : AbstractAsyncMessage
    {
		public override short Header => Headers.GameCenterRequestGamesEvent;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new GameCenterAchievementsListComposer());
        }
    }
}
