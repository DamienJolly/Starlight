using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Communication.Messages;
using System;
using System.Linq;
using System.Reflection;

namespace Starlight.Utils.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void RegisterDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterServices();
            serviceCollection.RegisterEvents();
        }

        private static void RegisterServices(this IServiceCollection serviceCollection)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IService)))
                    {
                        MethodInfo methodInfo = type.GetMethod("RegisterServices");
                        if (methodInfo == null)
                            continue;

                        object classInstance = Activator.CreateInstance(type, null);
                        object[] parametersArray = new object[] { serviceCollection };

                        type.GetMethod("RegisterServices").Invoke(classInstance, parametersArray);
                    }
                }
            }
        }

        private static void RegisterEvents(this IServiceCollection serviceCollection)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IMessageEvent)) && !type.IsAbstract)
                    {
                        serviceCollection.AddSingleton(typeof(IMessageEvent), type);
                    }
                }
            }
        }
    }
}
