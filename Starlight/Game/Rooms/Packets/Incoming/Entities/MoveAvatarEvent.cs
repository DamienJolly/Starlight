using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Rooms.Packets.Incoming.Entities.Args;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms.Packets.Incoming.Entities
{
    public class MoveAvatarEvent : AbstractMessageEvent<EntityMoveArgs>
    {
        public override short Header => Headers.MoveAvatarEvent;

        protected override Task HandleAsync(ISession session, EntityMoveArgs args)
        {
            session.Entity.Move(args.PositionX, args.PositionY);

            return Task.CompletedTask;
        }
    }
}
