using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class FavouriteRoomsComposer : MessageComposer
    {
        public FavouriteRoomsComposer() : base(Headers.FavouriteRoomsComposer)
        {

        }

        public override void Compose(IServerMessage packet)
        {
            packet.WriteInt(50);
            packet.WriteInt(0);
        }
    }
}
