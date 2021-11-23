using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.HotelView.Packets.Outgoing
{
    public class HotelViewDataComposer : MessageComposer
    {
        private readonly string Text;
        private readonly string Name;

        public HotelViewDataComposer(string text, string name) : base(Headers.HotelViewDataComposer)
        {
            Text = text;
            Name = name;
        }

        public override void Compose(IServerMessage packet)
        {
            packet.WriteString(Text);
            packet.WriteString(Name);
        }
    }
}
