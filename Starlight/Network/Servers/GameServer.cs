using DotNetty.Transport.Channels;
using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session;
using Starlight.API.Network.Servers;
using Starlight.Network.Codec;
using Starlight.Network.Handlers;

namespace Starlight.Network.Servers
{
    public class GameServer : AbstractServer
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ISessionController _sessionController;

        public GameServer(IMessageHandler messageHandler, ISessionController sessionController)
            : base("Game Server", "0.0.0.0", 30000, 1, 10)
        {
            _messageHandler = messageHandler;
            _sessionController = sessionController;
        }

		public override void InitializePipeline()
        {
            base.InitializePipeline();
            ServerBootstrap.ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
            {
                channel.Pipeline.AddLast("xmlDecoder", new GamePolicyDecoder());
                channel.Pipeline.AddLast("gameDecoder", new GameDecoder());
                channel.Pipeline.AddLast("gameEncoder", new GameEncoder());

                channel.Pipeline.AddLast("clientHandler", new GameNetworkHandler(_messageHandler, _sessionController));
            }));
        }
    }
}
