using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Handshake.Packets.Incoming.Args;
using Starlight.Game.Handshake.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Handshake.Packets.Incoming
{
    public class UniqueIdEvent : AbstractMessageEvent<UniqueIdArgs>
    {
		public override short Header => Headers.UniqueIdEvent;

        protected override async ValueTask Execute(ISession session, UniqueIdArgs args)
        {
            session.UniqueId = args.UniqueId;

            await session.WriteAndFlushAsync(new SetUniqueIdComposer(session.UniqueId));
        }
    }
}
