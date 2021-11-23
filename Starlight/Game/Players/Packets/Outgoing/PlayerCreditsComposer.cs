using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class PlayerCreditsComposer : MessageComposer
    {
        private readonly int Credits;

        public PlayerCreditsComposer(int credits) : base(Headers.PlayerCreditsComposer)
        {
            Credits = credits;
        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteString(Credits + ".0");
        }
    }
}
