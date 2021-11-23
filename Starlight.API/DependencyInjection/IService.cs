using Microsoft.Extensions.DependencyInjection;

namespace Starlight.API
{
    public interface IService
    {
        void RegisterServices(IServiceCollection serviceCollection);
    }
}
