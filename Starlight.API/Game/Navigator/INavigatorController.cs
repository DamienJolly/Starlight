using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.API.Game.Navigator
{
	public interface INavigatorController
	{
		/// <summary>
		/// Initialized the navigator data
		/// </summary>
		/// <param name="reloading">Is the data being reloaded</param>
		/// <returns>The task apon compleation</returns>
		ValueTask InitializeNavigator(bool reloading = true);

		/// <summary>
		/// Get a list of all navigator categories for the view name.
		/// </summary>
		/// <param name="view">The category view.</param>
		/// <returns>A list of navigator categories.</returns>
		IList<INavigatorCategory> TryGetCategoryByView(string view);
	}
}