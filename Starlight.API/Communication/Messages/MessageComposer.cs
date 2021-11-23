using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.API.Communication.Messages
{
	
    public abstract class MessageComposer
	{
        public short Header { get; }

        public MessageComposer(short header)
        {
            Header = header;
        }

        public virtual void Compose(IServerMessage packet) { }
    }
}
