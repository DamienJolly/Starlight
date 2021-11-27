using Starlight.API.Communication.Messages;
using Starlight.API.Game.HotelView;
using Starlight.API.Game.HotelView.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.HotelView.Packets.Outgoing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starlight.Game.HotelView.Packets.Incoming
{
	public class RequestNewsListEvent : AbstractAsyncMessage
	{
		public override short Header => Headers.RequestNewsListEvent;

		private readonly IHotelViewController _hotelViewController;

		public RequestNewsListEvent(IHotelViewController hotelViewController)
		{
			_hotelViewController = hotelViewController;
		}

		protected override async ValueTask Execute(ISession session)
		{
			IList<IArticle> articles = await _hotelViewController.GetNewsArticles();

			await session.WriteAndFlushAsync(new NewsListComposer(articles));
		}
	}
}