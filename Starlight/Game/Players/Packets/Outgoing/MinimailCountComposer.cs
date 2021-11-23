using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class MinimailCountComposer : MessageComposer
    {
        private readonly int Count;

        public MinimailCountComposer(int count) : base(Headers.MinimailCountComposer)
        {
            Count = count;
        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(Count);
        }
	}
}
