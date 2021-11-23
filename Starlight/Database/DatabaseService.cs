using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Database;

namespace Starlight.Database
{
    /// <summary>
    /// The database service initializes the required services.
    /// </summary>
    public class DatabaseService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDatabaseHandler, DatabaseHandler>();
        }
    }
}
