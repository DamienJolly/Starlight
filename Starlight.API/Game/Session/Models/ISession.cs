using Starlight.API.Communication.Messages;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Models;
using System;
using System.Threading.Tasks;

namespace Starlight.API.Game.Session.Models
{
    public interface ISession : IDisposable
    {
        /// <summary>
        /// The current room the player is in
        /// If player isn't in a room returns null
        /// </summary>
        IRoom CurrentRoom { get; set; }

        /// <summary>
        /// The current room entity the player is
        /// If player isn't in a room returns null
        /// </summary>
        IRoomEntity Entity { get; set; }

        /// <summary>
        /// The playerdata associated with the session.
        /// The player is set after the auth ticket.
        /// </summary>
        IPlayer Player { get; set; }

        /// <summary>
        /// The unique id from where the session is connected.
        /// </summary>
        string UniqueId { get; set; }

		/// <summary>
		/// Disconnect the current session
		/// </summary>
		Task Disconnect();

        /// <summary>
        /// Write the outgoing packet to the executor and flush the messages.
        /// </summary>
        /// <param name="msg">The packet to write.</param>
        /// <returns>Task completion.</returns>
        Task WriteAndFlushAsync(MessageComposer msg);

        /// <summary>
        /// Write the outgoing packet to the executor.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>Task completion.</returns>
        Task WriteAsync(MessageComposer msg);

        /// <summary>
        /// Flush the packets.
        /// </summary>
        void Flush();
    }
}
