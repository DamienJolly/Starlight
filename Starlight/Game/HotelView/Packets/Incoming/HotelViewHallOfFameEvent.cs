using Starlight.API.Communication.Messages;
using Starlight.API.Game.HotelView;
using Starlight.API.Game.HotelView.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.HotelView.Packets.Incoming.Args;
using Starlight.Game.HotelView.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView.Packets.Incoming
{
    public class HotelViewHallOfFameEvent : AbstractMessageEvent<WidgetDataArgs>
    {
        public override short Header => Headers.HotelViewHallOfFameEvent;

        private readonly IHotelViewController _hotelViewController;

        public HotelViewHallOfFameEvent(IHotelViewController hotelViewController)
        {
            _hotelViewController = hotelViewController;
        }

        protected override async ValueTask Execute(ISession session, WidgetDataArgs args)
        {
            string text = args.Text;
            IList<IHallOfFamer> hallOfFamers = await _hotelViewController.GetHallOfFamersAsync();

            await session.WriteAndFlushAsync(new HallOfFameComposer(hallOfFamers, text));
        }
    }
}
