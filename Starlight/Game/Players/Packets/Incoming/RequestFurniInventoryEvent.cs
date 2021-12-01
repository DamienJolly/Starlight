using Starlight.API.Communication.Messages;
using Starlight.API.Game.Items;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
	public class RequestFurniInventoryEvent : AbstractAsyncMessage
	{
		public override short Header => Headers.RequestFurniInventoryEvent;

		private readonly IItemController _itemController;

		public RequestFurniInventoryEvent(IItemController itemController)
		{
			_itemController = itemController;
		}

		protected override async ValueTask Execute(ISession session)
		{
			session.Player.InventoryComponent.Items = await _itemController.GetItemsForPlayer(session.Player.PlayerData.Id);

			await session.WriteAndFlushAsync(new FurniListComposer(session.Player.InventoryComponent.Items));
		}
	}
}