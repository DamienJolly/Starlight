using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class BuildersClubMembershipComposer : MessageComposer
    {
        public BuildersClubMembershipComposer() : base(Headers.BuildersClubMembershipComposer)
        {

        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(int.MaxValue);
            packet.WriteInt(100);
            packet.WriteInt(2);
        }
	}
}
