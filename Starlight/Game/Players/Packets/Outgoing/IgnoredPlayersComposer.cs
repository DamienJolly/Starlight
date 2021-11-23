using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class IgnoredPlayersComposer : MessageComposer
    {
        public IgnoredPlayersComposer() : base(Headers.IgnoredPlayersComposer)
        {

        }

		public override void Compose(IServerMessage message)
		{
            // Todo: Player ignores
            message.WriteInt(0); // Count
            {
                //message.WriteString(""); // Username
            }
        }
	}
}
