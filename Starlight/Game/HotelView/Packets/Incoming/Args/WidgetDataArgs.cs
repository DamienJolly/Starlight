using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.HotelView.Packets.Incoming.Args
{
    public class WidgetDataArgs : IMessageArgs
    {
        public string Text { get; private set; }

        public void Parse(IClientMessage message)
        {
            Text = message.ReadString();
        }
    }
}
