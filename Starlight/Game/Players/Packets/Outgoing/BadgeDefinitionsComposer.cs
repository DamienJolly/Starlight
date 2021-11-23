using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class BadgeDefinitionsComposer : MessageComposer
    {
        public BadgeDefinitionsComposer() : base(Headers.BadgeDefinitionsComposer)
        {

        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(0);
        }
	}
}
