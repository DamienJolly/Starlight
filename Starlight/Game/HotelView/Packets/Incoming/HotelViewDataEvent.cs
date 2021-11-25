using Starlight.API.Communication.Messages;
using Starlight.API.Game.Session.Models;
using Starlight.Game.HotelView.Packets.Incoming.Args;
using Starlight.Game.HotelView.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView.Packets.Incoming
{
    public class HotelViewDataEvent : AbstractMessageEvent<WidgetDataArgs>
    {
        public override short Header => Headers.HotelViewDataEvent;

        protected override async ValueTask Execute(ISession session, WidgetDataArgs args)
        {
            string text = args.Text;
            string name = string.Empty;

            string[] splitText = text.Split(',');
            if (splitText.Length >= 2)
            {
                name = splitText[1];
            }

            await session.WriteAndFlushAsync(new HotelViewDataComposer(text, name));
        }
    }
}
