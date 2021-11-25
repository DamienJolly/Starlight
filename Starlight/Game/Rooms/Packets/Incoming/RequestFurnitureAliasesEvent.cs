using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Rooms.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms.Packets.Incoming
{
    public class RequestFurnitureAliasesEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.RequestFurnitureAliasesEvent;

        protected override async ValueTask Execute(ISession session)
        {
            await session.WriteAndFlushAsync(new FurnitureAliasesComposer());
        }
    }
}
