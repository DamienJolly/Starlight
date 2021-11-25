namespace Starlight.Game.Catalog.Packets
{
    internal static class Headers
    {
        // Incoming
        internal const short GetCatalogIndexEvent = 1191;
        internal const short GetCatalogModeEvent = 2565;

        // Recycler
        internal const short GetRecyclerPrizesEvent = 862;

        // Outgoing
        internal const short CatalogPagesListComposer = 267;

        // Recycler
        internal const short RecyclerPrizesComposer = 455;
    }
}
