using DotNetty.Transport.Channels;
using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Communication.Messages.Protocols;
using System.Threading.Tasks;

namespace Starlight.Game.Sessions.Models
{
    public class Session : ISession
    {
        private bool _disconnected;
        private readonly IChannelHandlerContext _ctx;

        public Session(IChannelHandlerContext ctx)
        {
            _ctx = ctx;
        }

        public IRoom CurrentRoom { get; set; }

        public IRoomEntity Entity { get; set; }

        public IPlayer Player { get; set; }

        public string UniqueId { get; set; }

        public async Task Disconnect()
        {
            if (!_disconnected)
            {
                if (_ctx != null) await _ctx.CloseAsync();
                _disconnected = true;
            }
        }

        public async Task WriteAndFlushAsync(MessageComposer message) => 
            await _ctx.WriteAndFlushAsync(ComposePacket(message));

        public async Task WriteAsync(MessageComposer message) => 
            await _ctx.WriteAsync(ComposePacket(message));

        // Todo: Could this be a network encoder?
        private IServerMessage ComposePacket(MessageComposer message)
        {
            IServerMessage packet = new ServerMessage(message.Header);
            message.Compose(packet);
            return packet;
        }

        public void Flush() => _ctx.Flush();

        public void Dispose()
        {
            _disconnected = true;
            Player = null;
            UniqueId = string.Empty;
            _ctx.DisconnectAsync().Wait();
        }
    }
}