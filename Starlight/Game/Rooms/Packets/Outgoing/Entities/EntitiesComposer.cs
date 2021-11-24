using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Entities;
using System.Collections.Generic;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class EntitiesComposer : MessageComposer
    {
        private readonly IList<IRoomEntity> Entities;

        public EntitiesComposer(IList<IRoomEntity> entities) : base(Headers.EntitiesComposer)
        {
            Entities = entities;
        }

        public EntitiesComposer(IRoomEntity entity) : base(Headers.EntitiesComposer)
        {
			Entities = new List<IRoomEntity> { entity };
		}

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Entities.Count);
            foreach (IRoomEntity entity in Entities)
            {
                entity.Compose(message);
            }
        }
    }
}
