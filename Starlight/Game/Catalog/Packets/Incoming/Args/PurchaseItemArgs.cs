using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Incoming.Args
{
	public class PurchaseItemArgs : IMessageArgs
	{
		public int PageId { get; private set; }
		public int ItemId { get; private set; }
		public string ExtraData { get; private set; }
		public int Amount { get; private set; }

		public void Parse(IClientMessage message)
		{
			PageId = message.ReadInt();
			ItemId = message.ReadInt();
			ExtraData = message.ReadString();
			Amount = message.ReadInt();
		}
	}
}