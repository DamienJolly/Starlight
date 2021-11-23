namespace Starlight.Game.Navigator.Packets
{
	internal static class Headers
	{
		// Incoming
		internal const short InitializeNavigatorEvent = 2142;
		internal const short RequestNavigatorRoomCategoriesEvent = 3976;
		internal const short RequestNavigatorEventCategoriesEvent = 708;

		// Outgoing
		internal const short NavigatorMetaDataComposer = 2279;
		internal const short NavigatorLiftedRoomsComposer = 2525;
		internal const short NavigatorCollapsedCategoriesComposer = 2141;
		internal const short NavigatorEventCategoriesComposer = 3910;
		internal const short NavigatorSettingsComposer = 607;
		internal const short NavigatorSavedSearchesComposer = 1818;
		internal const short NavigatorRoomCategoriesComposer = 1084;
	}
}
