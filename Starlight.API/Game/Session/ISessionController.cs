using DotNetty.Transport.Channels;
using Starlight.API.Game.Session.Models;

namespace Starlight.API.Game.Session
{
    public interface ISessionController
    {
        /// <summary>
        /// Get a session without checking.
        /// </summary>
        /// <param name="channelId">The channel id.</param>
        /// <returns>The session if exists else null.</returns>
        ISession GetSession(IChannelId channelId);

        /// <summary>
        /// Tries to get session with checking. Please use within if statement else simply
        /// use <see cref="GetSession"/>
        /// </summary>
        /// <param name="channelId">The channel id</param>
        /// <param name="session">The usage entry</param>
        /// <returns>Wether or not the session exists.</returns>
        bool TryGetSession(IChannelId channelId, out ISession session);

        /// <summary>
        /// Adds the session to the cache.
        /// </summary>
        /// <param name="channel">The channel to assign to the session.</param>
        void AddSession(IChannelHandlerContext channel);

        /// <summary>
        /// Removes the session from the cache.
        /// </summary>
        /// <param name="channelId">The channel id to remove.</param>
        void RemoveSession(IChannelId channelId);
    }
}
