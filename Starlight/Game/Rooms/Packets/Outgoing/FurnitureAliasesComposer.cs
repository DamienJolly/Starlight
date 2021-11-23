using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Rooms.Packets.Outgoing
{
    public class FurnitureAliasesComposer : MessageComposer
    {
        public FurnitureAliasesComposer() : base(Headers.FurnitureAliasesComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(0);
        }
    }
}
