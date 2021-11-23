using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using System.Collections.Generic;
using System.Linq;

namespace Starlight.Game.Messenger.Packets.Incoming.Args
{
    public class DeclineArgs : IMessageArgs
    {
        public bool DeclineAll { get; private set; }
        public IList<uint> TargetIds { get; private set; }

        public void Parse(IClientMessage message)
        {
            DeclineAll = message.ReadBool();
            TargetIds = Enumerable.Range(0, message.ReadInt()).Select(_ => message.ReadUint()).ToList();
        }
    }
}
