using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
	public class PurchaseOKComposer : MessageComposer
	{
		private readonly ICatalogItem CatalogItem;

		public PurchaseOKComposer(ICatalogItem catalogItem) : base(Headers.PurchaseOKComposer)
		{
			CatalogItem = catalogItem;
		}

		public override void Compose(IServerMessage message)
		{
			CatalogItem.Compose(message);
		}
	}
}