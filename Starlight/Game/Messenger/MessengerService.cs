using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Messenger;

namespace Starlight.Game.Messenger
{
	/// <summary>
	/// The messenger service initializes the required services.
	/// </summary>
	public class MessengerService : IService
	{
		public void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<MessengerDao>();
			serviceCollection.AddSingleton<IMessengerController, MessengerController>();
		}
	}
}