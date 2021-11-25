using Starlight.API.Communication.Messages;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Rooms.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms.Packets.Incoming
{
    public class RequestRoomEntryDataEvent : AbstractAsyncMessage
    {
        public override short Header => Headers.RequestRoomEntryDataEvent;

        protected override async ValueTask Execute(ISession session)
        {
            IRoom room = session.CurrentRoom;
            if (room == null)
                return;

            await session.WriteAndFlushAsync(new HeightMapComposer(room.RoomModel));
            await session.WriteAndFlushAsync(new FloorHeightMapComposer(-1, room.RoomModel.RelativeHeightMap));

            room.AddPlayerEntity(session);

            await session.WriteAndFlushAsync(new RoomEntryInfoComposer(room.RoomData.Id, true));
            await session.WriteAndFlushAsync(new EntitiesComposer(room.Entity.Entities));
            await session.WriteAndFlushAsync(new EntitiesUpdateComposer(room.Entity.Entities));

            await session.WriteAndFlushAsync(new RoomVisualizationSettingsComposer(false, 0, 0));
        }
    }
}
