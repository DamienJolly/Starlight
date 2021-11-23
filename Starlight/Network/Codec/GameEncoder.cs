using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Starlight.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.Network.Codec
{
    /*public class GameEncoder : MessageToByteEncoder<MessageComposer>
    {
        protected override void Encode(IChannelHandlerContext context, MessageComposer message, IByteBuffer output)
        {
            ServerPacket packet = message.WriteMessage(output);
            packet.FinalizeBuffer();
        }
    }*/

    public class GameEncoder : MessageToMessageEncoder<ServerMessage>
    {
        protected override void Encode(IChannelHandlerContext context, ServerMessage message, List<object> output)
        {
            if (!message.HasLength)
            {
                message.ByteBuffer.SetInt(0, message.ByteBuffer.WriterIndex - 4);
            }

            output.Add(message.ByteBuffer);
        }
    }
}
