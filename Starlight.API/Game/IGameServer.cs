using System.Threading.Tasks;

namespace Starlight.API.Game
{
	public interface IGameServer
	{
		ValueTask StartGameServer();

		ValueTask StopGameServer();
	}
}