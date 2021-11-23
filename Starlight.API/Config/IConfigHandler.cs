using Starlight.API.Config.Configs;

namespace Starlight.API.Config
{
	public interface IConfigHandler
	{
		TConfig Get<TConfig>(string name) where TConfig : AbstractConfig;
	}
}
