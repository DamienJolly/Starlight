using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Players;

namespace Starlight.Game.Players
{
	/// <summary>
	/// The player service initializes the required services.
	/// </summary>
	public class PlayerService : IService
	{
		public void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<PlayerDao>();
			serviceCollection.AddSingleton<IPlayerController, PlayerController>();
		}
	}
}