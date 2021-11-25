using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Incoming.Args
{
    public class CatalogPageArgs : IMessageArgs
    {
        public int PageId { get; private set; }
        public int Unknown { get; private set; }
        public string Mode { get; private set; }

        public void Parse(IClientMessage message)
        {
            PageId = message.ReadInt();
            Unknown = message.ReadInt(); // Dunno?
            Mode = message.ReadString();
        }
    }
}
