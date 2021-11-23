using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Session;

namespace Starlight.Game.Sessions
{
    /// <summary>
    /// The session service initializes the required services.
    /// </summary>
    public class SessionService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SessionRepository>();
            serviceCollection.AddSingleton<ISessionController, SessionController>();
        }
    }
}
