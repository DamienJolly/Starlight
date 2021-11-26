using Starlight.API.Game.Catalog;

namespace Starlight.Game
{
	internal class Game
	{
		private readonly ICatalogController _catalogcontroller;

		public Game(ICatalogController catalogcontroller)
		{
			_catalogcontroller = catalogcontroller;
		}
	}
}