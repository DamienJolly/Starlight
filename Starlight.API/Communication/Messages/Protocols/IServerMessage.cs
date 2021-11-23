using DotNetty.Buffers;

namespace Starlight.API.Communication.Messages.Protocols
{
	public interface IServerMessage
	{
        short Header { get; }

        IByteBuffer ByteBuffer { get; }

        bool HasLength { get; }

        void WriteInt(int value);

        void WriteInt(uint value);

        void WriteShort(short value);

        void WriteByte(byte value);

        void WriteBoolean(bool value);

        void WriteString(string value);

        void WriteDouble(double value);
    }
}
