using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
	public class PurchaseErrorComposer : MessageComposer
	{
		public static readonly int SERVER_ERROR = 0;
		public static readonly int ALREADY_HAVE_BADGE = 1;

		private readonly int ErrorCode;

		public PurchaseErrorComposer(int errorCode) : base(Headers.PurchaseErrorComposer)
		{
			ErrorCode = errorCode;
		}

		public override void Compose(IServerMessage message)
		{
			message.WriteInt(ErrorCode);
		}
	}
}