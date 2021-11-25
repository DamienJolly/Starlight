using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.Game.Catalog.Packets.Incoming.Args
{
    public class CatalogModeArgs : IMessageArgs
    {
        public string Mode { get; private set; }

        public void Parse(IClientMessage message)
        {
            Mode = message.ReadString();
        }
    }
}
