using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Entities;
using System.Collections.Generic;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class EntitiesUpdateComposer : MessageComposer
    {
        private readonly IList<IRoomEntity> Entities;

        public EntitiesUpdateComposer(IList<IRoomEntity> entities) : base(Headers.EntitiesUpdateComposer)
        {
            Entities = entities;
        }

        public EntitiesUpdateComposer(IRoomEntity entity) : base(Headers.EntitiesUpdateComposer)
        {
			Entities = new List<IRoomEntity> { entity };
		}

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Entities.Count);
            foreach (IRoomEntity entity in Entities)
            {
                message.WriteInt(entity.Id);
                message.WriteInt(entity.Position.X);
                message.WriteInt(entity.Position.Y);
                message.WriteString(entity.Position.Z.ToString());
                message.WriteInt(entity.HeadRotation);
                message.WriteInt(entity.BodyRotation);
                message.WriteString(entity.Actions.StatusToString());
            }
        }
    }
}
