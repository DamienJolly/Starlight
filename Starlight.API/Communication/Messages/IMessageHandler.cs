using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.API.Communication.Messages
{
	public interface IMessageHandler
	{
		ValueTask HandlePacket(ISession session, IClientMessage message);
	}
}