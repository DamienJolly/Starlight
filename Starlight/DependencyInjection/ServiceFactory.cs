using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Starlight.Utils.Extensions;
using System;

namespace Starlight.DependencyInjection
{
	public class ServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddSerilog(dispose: true));

            serviceCollection.RegisterDependencies();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
	}
}
