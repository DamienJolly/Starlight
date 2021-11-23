using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.API.Communication.Messages
{
	public interface IMessageArgs
	{
		void Parse(IClientMessage message);
	}
}
