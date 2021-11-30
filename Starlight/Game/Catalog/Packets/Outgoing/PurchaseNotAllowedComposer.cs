using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
	public class PurchaseNotAllowedComposer : MessageComposer
	{
		public static readonly int ILLEGAL = 0;
		public static readonly int REQUIRES_CLUB = 1;

		private readonly int ErrorCode;

		public PurchaseNotAllowedComposer(int errorCode) : base(Headers.PurchaseNotAllowedComposer)
		{
			ErrorCode = errorCode;
		}

		public override void Compose(IServerMessage message)
		{
			message.WriteInt(ErrorCode);
		}
	}
}