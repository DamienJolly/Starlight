using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
	//Todo: Player points
	public class PlayerPointsComposer : MessageComposer
	{
		public PlayerPointsComposer() : base(Headers.PlayerPointsComposer)
		{
		}

		public override void Compose(IServerMessage message)
		{
			message.WriteInt(1);
			{
				message.WriteInt(0);
				message.WriteInt(2000);
			}
		}
	}
}