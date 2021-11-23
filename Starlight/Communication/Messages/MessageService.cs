using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Communication.Messages;

namespace Starlight.Communication.Messages
{
    /// <summary>
    /// The message service initializes the required services.
    /// </summary>
    public class MessageService : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMessageHandler, MessageHandler>();
        }
    }
}

