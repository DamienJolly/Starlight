namespace Starlight.Game.Catalog.Packets
{
	internal static class Headers
	{
		// Incoming
		internal const short GetCatalogIndexEvent = 1191;

		internal const short GetCatalogModeEvent = 2565;
		internal const short GetGiftWrappingConfigurationEvent = 3493;
		internal const short GetDiscountEvent = 703;
		internal const short GetCatalogPageEvent = 3547;
		internal const short CatalogSearchedItemEvent = 1846;
		internal const short PurchaseFromCatalogEvent = 2687;

		// Recycler
		internal const short GetRecyclerPrizesEvent = 862;

		// Marketplace
		internal const short GetMarketplaceConfigurationEvent = 1728;

		// Outgoing
		internal const short CatalogPagesListComposer = 267;

		internal const short GiftWrappingConfigurationComposer = 1353;
		internal const short DiscountComposer = 1602;
		internal const short CatalogPageComposer = 3933;
		internal const short CatalogSearchResultComposer = 2090;
		internal const short CatalogModeComposer = 363;
		internal const short PurchaseErrorComposer = 1103;
		internal const short PurchaseNotAllowedComposer = 472;
		internal const short PurchaseOKComposer = 3661;

		// Recycler
		internal const short RecyclerPrizesComposer = 455;

		// Marketplace
		internal const short MarketplaceConfigurationComposer = 3802;
	}
}