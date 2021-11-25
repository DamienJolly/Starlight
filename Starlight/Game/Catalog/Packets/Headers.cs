namespace Starlight.Game.Catalog.Packets
{
    internal static class Headers
    {
        // Incoming
        internal const short GetCatalogIndexEvent = 1191;
        internal const short GetCatalogModeEvent = 2565;

        // Recycler
        internal const short GetRecyclerPrizesEvent = 862;

        // Marketplace
        internal const short GetMarketplaceConfigurationEvent = 1728;

        // Outgoing
        internal const short CatalogPagesListComposer = 267;

        // Recycler
        internal const short RecyclerPrizesComposer = 455;

        // Marketplace
        internal const short MarketplaceConfigurationComposer = 3802;
    }
}
