using Microsoft.Extensions.Logging;
using Starlight.API.Game.Navigator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.Navigator
{
    internal class NavigatorRepository
    {
        private readonly ILogger<NavigatorRepository> _logger;
        private readonly NavigatorDao _navigatorDao;
        private IDictionary<string, INavigatorCategory> _categories;
        private readonly IList<string> _views = new List<string>
            {
                "official_view",
                "hotel_view",
                "myworld_view"
            };

        public NavigatorRepository(ILogger<NavigatorRepository> logger, NavigatorDao navigatorDao)
        {
            _logger = logger;
            _navigatorDao = navigatorDao;

            _categories = new Dictionary<string, INavigatorCategory>();

            InitializeNavigator().Wait();
        }

        internal async Task InitializeNavigator()
        {
            _categories.Clear();

            _categories = await _navigatorDao.GetNavigatorCategories();

            _logger.LogInformation("Loaded {0} navigator categories", _categories.Count);
        }

        internal IList<INavigatorCategory> TryGetCategoryByView(string view)
        {
            IList<INavigatorCategory> categories = new List<INavigatorCategory>();
            foreach (INavigatorCategory category in _categories.Values)
            {
                if (category.View == view)
                    categories.Add(category);
            }
            return categories;
        }
    }
}
