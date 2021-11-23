using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.API.Communication.Messages
{
    public abstract class AbstractMessageEvent<TArgs> : IMessageEvent
        where TArgs : IMessageArgs, new()
    {
        public abstract short Header { get; }

        protected abstract Task HandleAsync(ISession session, TArgs args);

        public Task HandleAsync(ISession session, IClientMessage message)
        {
            TArgs args = new TArgs();
            args.Parse(message);

            return HandleAsync(session, args);
        }
    }

    public abstract class AbstractAsyncMessage : IMessageEvent
    {
        public abstract short Header { get; }

        protected abstract Task HandleAsync(ISession session);

        public Task HandleAsync(ISession session, IClientMessage message)
        {
            return HandleAsync(session);
        }
    }
}
