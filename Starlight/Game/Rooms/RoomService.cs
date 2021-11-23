using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Rooms;

namespace Starlight.Game.Rooms
{
    /// <summary>
    /// The room service initializes the required services.
    /// </summary>
    public class RoomService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<RoomDao>();
            serviceCollection.AddSingleton<RoomRepository>();
            serviceCollection.AddSingleton<IRoomController, RoomController>();
        }
    }
}
