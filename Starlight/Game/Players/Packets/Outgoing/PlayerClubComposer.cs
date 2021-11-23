using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    //Todo: Player club
    public class PlayerClubComposer : MessageComposer
    {
        public PlayerClubComposer() : base(Headers.PlayerClubComposer)
        {

        }

		public override void Compose(IServerMessage message)
		{
			message.WriteString("habbo_club");
			message.WriteInt(0); //display days
			message.WriteInt(2);
			message.WriteInt(0); //display months
			message.WriteInt(1);
			message.WriteBoolean(true); // hc
			message.WriteBoolean(true); // vip
			message.WriteInt(0);
			message.WriteInt(0);
			message.WriteInt(495);
		}
	}
}
