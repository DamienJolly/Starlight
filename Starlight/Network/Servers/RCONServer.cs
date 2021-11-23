using DotNetty.Transport.Channels;
using Starlight.API.Game.Session;
using Starlight.API.Network.Servers;

namespace Starlight.Network.Servers
{
    public class RCONServer : AbstractServer
    {
        private readonly ISessionController _sessionController;

        public RCONServer(ISessionController sessionController)
            : base("RCON Server", "0.0.0.0", 30001, 1, 10)
        {
            _sessionController = sessionController;
        }

		public override void InitializePipeline()
        {
            base.InitializePipeline();
            ServerBootstrap.ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
            {
                //channel.Pipeline.AddLast("RCONHandler", new RCONNetworkHandler(_sessionController));
            }));
        }
    }
}
