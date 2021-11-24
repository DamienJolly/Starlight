using Starlight.API.Communication.Messages;
using Starlight.API.Game.Rooms;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Rooms.Packets.Incoming.Args;
using Starlight.Game.Rooms.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Rooms.Packets.Incoming
{
    public class RequestRoomLoadEvent : AbstractMessageEvent<RoomLoadArgs>
    {
        public override short Header => Headers.RequestRoomLoadEvent;

        private readonly IRoomController _roomController;

        public RequestRoomLoadEvent(IRoomController roomController)
        {
            _roomController = roomController;
        }

        protected override async Task HandleAsync(ISession session, RoomLoadArgs args)
        {
            IRoom room = await _roomController.LoadRoomByIdAsync(args.RoomId);
            if (room == null)
            {
                await session.WriteAndFlushAsync(new RoomCloseComposer());
                return;
            }

            session.CurrentRoom = room;

            await session.WriteAndFlushAsync(new RoomOpenComposer());
            await session.WriteAndFlushAsync(new RoomModelComposer(room.RoomData));
            //await session.WriteAndFlushAsync(new RoomScoreComposer(room.Score));
        }
    }
}
