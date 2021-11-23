using DotNetty.Buffers;
using Starlight.API.Communication.Messages.Protocols;
using System.Text;

namespace Starlight.Communication.Messages.Protocols
{
    public class ServerMessage : IServerMessage
    {
        public short Header { get; }
        public IByteBuffer ByteBuffer { get; }

        public ServerMessage(short header)
        {
            Header = header;
            ByteBuffer = Unpooled.Buffer();
            WriteInt(-1);
            WriteShort(header);
        }

        public bool HasLength =>
            ByteBuffer.GetInt(0) > -1;

        public void WriteInt(int value) =>
            ByteBuffer.WriteInt(value);

        public void WriteInt(uint value) =>
            ByteBuffer.WriteInt((int)value);

        public void WriteShort(short value) =>
            ByteBuffer.WriteShort(value);

        public void WriteByte(byte value) =>
            ByteBuffer.WriteByte(value);

        public void WriteBoolean(bool value) =>
            ByteBuffer.WriteBoolean(value);

        public void WriteString(string value)
        {
            ByteBuffer.WriteShort(value.Length);
            ByteBuffer.WriteBytes(Encoding.UTF8.GetBytes(value));
        }

        public void WriteDouble(double value) =>
            WriteString(value.ToString());
    }
}
