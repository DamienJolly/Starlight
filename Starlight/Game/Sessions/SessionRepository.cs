using DotNetty.Transport.Channels;
using Starlight.API.Game.Players;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Sessions.Models;
using System.Collections.Generic;

namespace Starlight.Game.Sessions
{
    internal class SessionRepository
    {
        private readonly IPlayerController _playerController;
        private readonly IDictionary<IChannelId, ISession> _sessions;

        public SessionRepository(IPlayerController playerController)
        {
            _playerController = playerController;

            _sessions = new Dictionary<IChannelId, ISession>();
        }

        internal ISession GetSession(IChannelId channelId) =>
            _sessions[channelId];

        internal bool TryGetSession(IChannelId channelId, out ISession session) =>
            _sessions.TryGetValue(channelId, out session);

        internal void AddSession(IChannelHandlerContext channel) =>
            _sessions.Add(channel.Channel.Id, new Session(channel));

        internal void RemoveSession(IChannelId channelId)
        {
            if (TryGetSession(channelId, out ISession session))
            {
                if (session.Player != null)
                {
                    _playerController.RemovePlayer(session.Player);
                }

                session.Dispose();
            }
            _sessions.Remove(channelId);
        }
    }
}
