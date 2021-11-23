using Starlight.API.Game.Navigator;
using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;

namespace Starlight.Game.Navigator
{
    internal class NavigatorController : INavigatorController
    {
        private readonly NavigatorRepository _navigatorRepository;

        public NavigatorController(NavigatorRepository navigatorRepository)
        {
            _navigatorRepository = navigatorRepository; ;
        }

        public IList<INavigatorCategory> TryGetCategoryByView(string view) =>
            _navigatorRepository.TryGetCategoryByView(view);
    }
}
