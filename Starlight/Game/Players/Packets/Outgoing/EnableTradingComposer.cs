using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class EnableNotificationsComposer : MessageComposer
    {
		public bool Enabled;

		public EnableNotificationsComposer(bool enabled) : base(Headers.EnableNotificationsComposer)
        {
			Enabled = enabled;
		}

		public override void Compose(IServerMessage packet)
		{
			packet.WriteBoolean(Enabled);
		}
	}
}
