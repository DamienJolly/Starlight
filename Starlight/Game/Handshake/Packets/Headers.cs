namespace Starlight.Game.Handshake.Packets
{
    internal static class Headers
    {
        // Incoming
        internal const short CheckReleaseEvent = 4000;
        internal const short CheckVariablesEvent = 410;
        internal const short UniqueIdEvent = 3465;
        internal const short LatencyEvent = 3047;
        internal const short LatencyMeasureEvent = 3525;
        internal const short PongEvent = 2596;

        // Outgoing
        internal const short SetUniqueIdComposer = 547;
        internal const short LatencyComposer = 3346;
        internal const short PingComposer = 3644;
    }
}
