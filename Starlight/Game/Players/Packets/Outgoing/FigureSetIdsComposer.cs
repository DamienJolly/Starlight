using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class FigureSetIdsComposer : MessageComposer
    {
        public FigureSetIdsComposer() : base(Headers.FigureSetIdsComposer)
        {

        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(0);

            packet.WriteInt(0);
        }
	}
}
