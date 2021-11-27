using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;
using Starlight.Game.Catalog.Layouts;

namespace Starlight.Game.Catalog.Utils
{
	public class CatalogLayoutUtility
	{
		public static CatalogLayout GetCatalogLayout(string layout, ICatalogPage catalogPage)
		{
			return layout.ToLower() switch
			{
				"frontpage" => new LayoutFrontpage(catalogPage),
				"badge_display" => new LayoutBadgeDisplay(catalogPage),
				"spaces_new" => new LayoutSpacesNew(catalogPage),
				"trophies" => new LayoutTrophies(catalogPage),
				"bots" => new LayoutBot(catalogPage),
				"club_buy" => new LayoutClubBuy(catalogPage),
				"club_gift" => new LayoutClubGifts(catalogPage),
				"sold_ltd_items" => new LayoutSoldLTDItems(catalogPage),
				"single_bundle" => new LayoutSingleBundle(catalogPage),
				"roomads" => new LayoutRoomAds(catalogPage),
				"recycler" => new LayoutRecycler(catalogPage),
				"recycler_info" => new LayoutRecyclerInfo(catalogPage),
				"recycler_prizes" => new LayoutRecyclerPrizes(catalogPage),
				"marketplace" => new LayoutMarketplace(catalogPage),
				"marketplace_own_items" => new LayoutMarketplaceOwnItems(catalogPage),
				"info_duckets" => new LayoutInfoDuckets(catalogPage),
				"info_pets" => new LayoutInfoPets(catalogPage),
				"info_rentables" => new LayoutInfoRentables(catalogPage),
				"info_loyalty" => new LayoutInfoLoyalty(catalogPage),
				"loyalty_vip_buy" => new LayoutLoyaltyVipBuy(catalogPage),
				"guilds" => new LayoutGroup(catalogPage),
				"guild_furni" => new LayoutGroupItems(catalogPage),
				"guild_forum" => new LayoutGroupForum(catalogPage),
				"pets" => new LayoutPets(catalogPage),
				"pets2" => new LayoutPets2(catalogPage),
				"pets3" => new LayoutPets3(catalogPage),
				"soundmachine" => new LayoutTrax(catalogPage),
				"default_3x3_color_grouping" => new LayoutColorGrouping(catalogPage),
				"petcustomization" => new LayoutPetCustomization(catalogPage),
				"vip_buy" => new LayoutVipBuy(catalogPage),
				"frontpage_featured" => new LayoutFrontPageFeatured(catalogPage),
				"builders_club_addons" => new LayoutBuildersClubAddons(catalogPage),
				"builders_club_frontpage" => new LayoutBuildersClubFrontPage(catalogPage),
				"builders_club_loyalty" => new LayoutBuildersClubLoyalty(catalogPage),
				_ => new LayoutDefault(catalogPage),
			};
		}
	}
}