using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Starlight.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.Network.Codec
{
    public class GameDecoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            int length = input.ReadInt();

            if (input.ReadableBytes < length || length < 0)
            {
                input.ResetReaderIndex();
                return;
            }
            output.Add(new ClientMessage(input.ReadBytes(length)));
        }
    }
}
