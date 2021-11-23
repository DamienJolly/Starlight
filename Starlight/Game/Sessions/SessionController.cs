using DotNetty.Transport.Channels;
using Starlight.API.Game.Session;
using Starlight.API.Game.Session.Models;

namespace Starlight.Game.Sessions
{
    internal class SessionController : ISessionController
    {
        private readonly SessionRepository _sessionRepository;

        public SessionController(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ISession GetSession(IChannelId channelId) =>
            _sessionRepository.GetSession(channelId);

        public bool TryGetSession(IChannelId channelId, out ISession session) =>
            _sessionRepository.TryGetSession(channelId, out session);

        public void AddSession(IChannelHandlerContext channel) =>
            _sessionRepository.AddSession(channel);

        public void RemoveSession(IChannelId channelId) =>
            _sessionRepository.RemoveSession(channelId);
    }
}
