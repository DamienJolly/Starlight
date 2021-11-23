using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Handshake.Packets.Outgoing
{
    public class SetUniqueIdComposer : MessageComposer
    {
        private readonly string UniqueId;

        public SetUniqueIdComposer(string uniqueId)
            : base(Headers.SetUniqueIdComposer)
        {
            UniqueId = uniqueId;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteString(UniqueId);
        }
    }
}
