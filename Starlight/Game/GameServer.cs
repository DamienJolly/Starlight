using Starlight.API.Game;
using Starlight.API.Game.Catalog;
using Starlight.API.Game.Items;
using Starlight.API.Game.Navigator;
using Starlight.API.Game.Rooms;
using System.Threading.Tasks;

namespace Starlight.Game
{
	internal class GameServer : IGameServer
	{
		private readonly ICatalogController _catalogController;
		private readonly INavigatorController _navigatorController;
		private readonly IRoomController _roomController;
		private readonly IItemController _itemController;

		public GameServer(ICatalogController catalogController, INavigatorController navigatorController, IRoomController roomController, IItemController itemController)
		{
			_catalogController = catalogController;
			_navigatorController = navigatorController;
			_roomController = roomController;
			_itemController = itemController;
		}

		public async ValueTask StartGameServer()
		{
			await _itemController.InitializeItems(false);
			await _catalogController.InitializeCatalog(false);
			await _navigatorController.InitializeNavigator(false);
			await _roomController.InitializeRoomModels(false);
		}

		public ValueTask StopGameServer()
		{
			// Dispose
			return default;
		}
	}
}