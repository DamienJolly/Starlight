using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;

namespace Starlight.API.Game.Navigator
{
	public interface INavigatorController
	{
		/// <summary>
		/// Get a list of all navigator categories for the view name.
		/// </summary>
		/// <param name="view">The category view.</param>
		/// <returns>A list of navigator categories.</returns>
		IList<INavigatorCategory> TryGetCategoryByView(string view);
	}
}
