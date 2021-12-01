using Starlight.API.Game.Items.Models;
using System.Collections.Generic;

namespace Starlight.API.Game.Players.Components
{
	public interface IInventoryComponent
	{
		IList<IItem> Items { get; set; }
	}
}