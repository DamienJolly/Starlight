using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Network.Codec
{
    public class GamePolicyDecoder : ByteToMessageDecoder
    {
        private static readonly string POLICY = "<?xml version=\"1.0\"?>\r\n"
                + "<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n"
                + "<cross-domain-policy>\r\n"
                + "<allow-access-from domain=\"*\" to-ports=\"*\" />\r\n"
                + "</cross-domain-policy>\0)";

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            input.MarkReaderIndex();
            if (input.ReadableBytes < 1) return;

            byte delimiter = input.ReadByte();
            input.ResetReaderIndex();

            if (delimiter == 60)
            {
                context.WriteAndFlushAsync(Unpooled.CopiedBuffer(Encoding.Default.GetBytes(POLICY)));
                return;
            }

            context.Channel.Pipeline.Remove(this);
        }
    }
}
