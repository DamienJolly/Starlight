using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.API.Communication.Messages
{
    public interface IMessageEvent
    {
        /// <summary>
        /// The op-code to figure out which event this is used to handle.
        /// </summary>
        short Header { get; }

        /// <summary>
        /// Handles the incoming packet asynchronously.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="message">The packet that comes with the message.</param>
        /// <returns>The event handled upon task completion.</returns>
        Task HandleAsync(ISession session, IClientMessage message);
    }
}
