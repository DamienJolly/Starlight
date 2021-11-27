﻿using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;

namespace Starlight.Game.Catalog.Layouts
{
	public class LayoutGroup : CatalogLayout
	{
		public LayoutGroup(ICatalogPage catalogPage) : base(catalogPage)
		{
		}

		public override void ComposePageData(IServerMessage message)
		{
			message.WriteString("guild_frontpage");
			message.WriteInt(2);
			message.WriteString(CatalogPage.HeaderImage);
			message.WriteString(CatalogPage.TeaserImage);
			message.WriteInt(3);
			message.WriteString(CatalogPage.TextOne);
			message.WriteString(CatalogPage.TextDetails);
			message.WriteString(CatalogPage.TextTeaser);
		}
	}
}