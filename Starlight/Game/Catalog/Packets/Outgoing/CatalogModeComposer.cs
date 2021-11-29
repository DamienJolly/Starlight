using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
	public class CatalogModeComposer : MessageComposer
	{
		private readonly string Mode;

		public CatalogModeComposer(string mode)
			: base(Headers.CatalogModeComposer)
		{
			Mode = mode;
		}

		public override void Compose(IServerMessage message)
		{
			message.WriteInt(GetModeId(Mode));
		}

		private int GetModeId(string mode) => mode switch
		{
			"builders_club" => 1,
			_ => 0,
		};
	}
}