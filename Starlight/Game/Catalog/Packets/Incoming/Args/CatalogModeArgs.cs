using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Incoming.Args
{
	public class CatalogModeArgs : IMessageArgs
	{
		public string Mode { get; private set; }

		public void Parse(IClientMessage message)
		{
			Mode = message.ReadString().ToUpper();
		}
	}
}