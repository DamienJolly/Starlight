namespace Starlight.Game.Rooms.Packets
{
	internal static class Headers
	{
		// Incoming
		internal const short RequestRoomLoadEvent = 3464;
		internal const short RequestFurnitureAliasesEvent = 2443;
		internal const short RequestRoomEntryDataEvent = 1583;

		// Outgoing
		internal const short RoomOpenComposer = 1975;
		internal const short RoomCloseComposer = 2484;
		internal const short RoomEntryErrorComposer = 3107;
		internal const short RoomModelComposer = 1303;
		internal const short FurnitureAliasesComposer = 2958;
		internal const short HeightMapComposer = 322;
		internal const short FloorHeightMapComposer = 1909;
	}
}
