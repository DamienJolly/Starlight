using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    //Todo: Player sanctions
    public class PlayerSanctionsComposer : MessageComposer
    {
        public PlayerSanctionsComposer() : base(Headers.PlayerSanctionsComposer)
        {

        }

		public override void Compose(IServerMessage message)
		{
            message.WriteBoolean(false); // Has previous sanction
            message.WriteBoolean(false); // Is on probation
            message.WriteString("ALERT"); // Last sanction type
            message.WriteInt(0); // Time of current sanction
            message.WriteInt(30); // Dunno?
            message.WriteString("cfh.reason.EMPTY"); // Sanction reason
            message.WriteString(""); // Probation start time
            message.WriteInt(0); // Dunno?
            message.WriteString("ALERT"); // Next sanction type
            message.WriteInt(0); // Time to be applied in next sanction (in hours)
            message.WriteInt(30); // Dunno?
            message.WriteBoolean(false); // Is muted
            message.WriteString(""); // Trade locked until
        }
    }
}
