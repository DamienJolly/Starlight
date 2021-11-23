using DotNetty.Transport.Channels;
using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session;
using Starlight.API.Game.Session.Models;
using Starlight.Communication.Messages.Protocols;

namespace Starlight.Network.Handlers
{
    public class GameNetworkHandler : SimpleChannelInboundHandler<ClientMessage>
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ISessionController _sessionController;

        public GameNetworkHandler(IMessageHandler messageHandler, ISessionController sessionController)
        {
            _messageHandler = messageHandler;
            _sessionController = sessionController;
        }

        public override void ChannelActive(IChannelHandlerContext context) =>
            _sessionController.AddSession(context);

        public override void ChannelInactive(IChannelHandlerContext context) =>
            _sessionController.RemoveSession(context.Channel.Id);

        protected override async void ChannelRead0(IChannelHandlerContext ctx, ClientMessage msg)
        {
            ISession session = _sessionController.GetSession(ctx.Channel.Id);

            await _messageHandler.TriggerEventAsync(session, msg);
        }
    }
}
