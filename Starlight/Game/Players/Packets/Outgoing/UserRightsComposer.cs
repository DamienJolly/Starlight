using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class UserRightsComposer : MessageComposer
    {
        private readonly int Rank;

        public UserRightsComposer(int rank) : base(Headers.UserRightsComposer)
        {
            Rank = rank;
        }

		public override void Compose(IServerMessage packet)
		{
            //TODO: Ambassadors, habbo club.
            packet.WriteInt(2);
            packet.WriteInt(Rank);
            packet.WriteBoolean(false); //Is an ambassador
        }
	}
}
