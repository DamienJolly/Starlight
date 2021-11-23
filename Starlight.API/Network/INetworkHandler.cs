using System.Threading.Tasks;

namespace Starlight.API.Network
{
	public interface INetworkHandler
	{
		Task StartServerAsync(string name);

		Task StopServerAsync(string name);

		Task ServerShutdown();
	}
}
