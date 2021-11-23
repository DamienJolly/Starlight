using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.HotelView;

namespace Starlight.Game.HotelView
{
    /// <summary>
    /// The hotel view service initializes the required services.
    /// </summary>
    public class HotelViewService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<HotelViewDao>();
            serviceCollection.AddSingleton<HotelViewRepository>();
            serviceCollection.AddSingleton<IHotelViewController, HotelViewController>();
        }
    }
}
