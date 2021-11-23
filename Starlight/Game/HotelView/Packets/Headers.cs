namespace Starlight.Game.HotelView.Packets
{
    internal static class Headers
    {
        // Incoming
        internal const short HotelViewDataEvent = 1579;
        internal const short RequestNewsListEvent = 1156;
        internal const short HotelViewHallOfFameEvent = 3100;

        // Outgoing
        internal const short HotelViewDataComposer = 730;
        internal const short HallOfFameComposer = 1243;
        internal const short NewsListComposer = 811;
    }
}