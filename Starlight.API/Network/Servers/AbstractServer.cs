using DotNetty.Buffers;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System.Net;
using System.Threading.Tasks;

namespace Starlight.API.Network.Servers
{
	public abstract class AbstractServer
	{
        public string Name;
        public string Host;
        public int Port;
        public ServerBootstrap ServerBootstrap;

        private readonly IEventLoopGroup _bossGroup;
        private readonly IEventLoopGroup _workerGroup;

        public AbstractServer(string name, string host, int port, int bossGroupThreads, int workerGroupThreads)
        {
            Name = name;
            Host = host;
            Port = port;

            _bossGroup = new MultithreadEventLoopGroup(bossGroupThreads);
            _workerGroup = new MultithreadEventLoopGroup(workerGroupThreads);
            ServerBootstrap = new ServerBootstrap();
        }

        public virtual void InitializePipeline()
        {
            ServerBootstrap.Group(_bossGroup, _workerGroup);
            ServerBootstrap.Channel<TcpServerSocketChannel>();
            ServerBootstrap.ChildOption(ChannelOption.TcpNodelay, true);
            ServerBootstrap.ChildOption(ChannelOption.SoKeepalive, true);
            ServerBootstrap.ChildOption(ChannelOption.SoReuseaddr, true);
            ServerBootstrap.ChildOption(ChannelOption.SoRcvbuf, 1024);
            ServerBootstrap.ChildOption(ChannelOption.RcvbufAllocator, new FixedRecvByteBufAllocator(1024));
            ServerBootstrap.ChildOption(ChannelOption.Allocator, UnpooledByteBufferAllocator.Default);
        }

        public async Task<bool> TryConnectAsync()
        {
			return (await ServerBootstrap.BindAsync(new IPEndPoint(IPAddress.Parse(Host), Port))).Active;
        }

        public async Task StopAsync()
        {
            await _workerGroup.ShutdownGracefullyAsync();
            await _bossGroup.ShutdownGracefullyAsync();
        }
    }
}
