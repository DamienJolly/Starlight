namespace Starlight.Game.Players.Packets
{
	internal static class Headers
	{
		// Incoming
		internal const short SecureLoginEvent = 1930;

		internal const short UserActivityEvent = 1187;
		internal const short RequestPlayerDataEvent = 3092;
		internal const short RequestPlayerSettingsEvent = 3537;
		internal const short RequestPlayerIgnoresEvent = 3822;
		internal const short RequestPlayerCurrenciesEvent = 2109;
		internal const short RequestPlayerClubEvent = 3796;
		internal const short RequestPlayerSanctionsEvent = 1373;
		internal const short RequestFurniInventoryEvent = 2835;

		// Outgoing
		internal const short AuthenticationOkComposer = 3412;

		internal const short HomeRoomComposer = 908;
		internal const short FavouriteRoomsComposer = 0;
		internal const short FigureSetIdsComposer = 2187;
		internal const short UserRightsComposer = 2946;
		internal const short AvailabilityStatusComposer = 770;
		internal const short BuildersClubMembershipComposer = 1059;
		internal const short EnableNotificationsComposer = 2139;
		internal const short CfhTopicsInitComposer = 463;
		internal const short BadgeDefinitionsComposer = 0;
		internal const short PlayerSettingsComposer = 2204;
		internal const short UserDataComposer = 3862;
		internal const short UserPerksComposer = 1105;
		internal const short MinimailCountComposer = 1578;
		internal const short IgnoredPlayersComposer = 2317;
		internal const short PlayerCreditsComposer = 1232;
		internal const short PlayerPointsComposer = 2380;
		internal const short PlayerClubComposer = 2984;
		internal const short PlayerSanctionsComposer = 2031;
		internal const short FurniListComposer = 826;
	}
}