using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Incoming.Args
{
	public class SearchItemArgs : IMessageArgs
	{
		public int OfferId { get; private set; }

		public void Parse(IClientMessage message)
		{
			OfferId = message.ReadInt();
		}
	}
}