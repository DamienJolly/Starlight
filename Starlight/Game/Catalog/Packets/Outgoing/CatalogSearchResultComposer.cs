using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
	public class CatalogSearchResultComposer : MessageComposer
	{
		private readonly ICatalogItem CatalogItem;

		public CatalogSearchResultComposer(ICatalogItem catalogItem)
			: base(Headers.CatalogSearchResultComposer)
		{
			CatalogItem = catalogItem;
		}

		public override void Compose(IServerMessage message)
		{
			CatalogItem.Compose(message);
		}
	}
}