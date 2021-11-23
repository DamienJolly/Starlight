using DotNetty.Buffers;
using Starlight.API.Communication.Messages.Protocols;
using System.Text;

namespace Starlight.Communication.Messages.Protocols
{
    public class ClientMessage : IClientMessage
    {
        public short Header { get; }
        private readonly IByteBuffer _buf;

        public ClientMessage(IByteBuffer buffer)
        {
            _buf = buffer;
            Header = ReadShort();
        }

        public short ReadShort() =>
            _buf.ReadShort();

        public byte ReadByte() =>
            _buf.ReadByte();

        public byte[] ReadBytes(int length) =>
            _buf.ReadBytes(length).Array;

        public bool ReadBool() =>
            _buf.ReadByte() == 1;

        public int ReadInt() =>
            _buf.ReadInt();

        public uint ReadUint() =>
            _buf.ReadUnsignedInt();

        public string ReadString() =>
            _buf.ReadString(ReadShort(), Encoding.UTF8);

        public override string ToString() =>
            Encoding.UTF8.GetString(_buf.Array);
    }
}
