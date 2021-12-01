using Starlight.API.Game.Items.Models;
using Starlight.API.Game.Players.Components;
using Starlight.API.Game.Players.Models;
using System.Collections.Generic;

namespace Starlight.Game.Players.Components
{
	public class InventoryComponent : IInventoryComponent
	{
		private readonly IPlayer _player;

		public IList<IItem> Items { get; set; }

		public InventoryComponent(IPlayer player)
		{
			_player = player;

			Items = new List<IItem>();
		}
	}
}