using Starlight.API.Game.Catalog.Layouts;
using Starlight.API.Game.Catalog.Models;
using System.Collections.Generic;

namespace Starlight.Game.Catalog.Models
{
	public class CatalogPage : ICatalogPage
	{
		public int Id { get; }
		public int ParentId { get; }
		public string Name { get; }
		public string Caption { get; }
		public int Icon { get; }
		public int Rank { get; }
		public string HeaderImage { get; }
		public string TeaserImage { get; }
		public string SpecialImage { get; }
		public string TextOne { get; }
		public string TextTwo { get; }
		public string TextDetails { get; }
		public string TextTeaser { get; }
		public string Layout { get; }
		public bool Enabled { get; }
		public bool Visible { get; }

		public CatalogLayout PageLayout { get; set; }
		public IDictionary<int, ICatalogItem> Items { get; set; }
		public IList<int> OfferIds { get; set; }
	}
}