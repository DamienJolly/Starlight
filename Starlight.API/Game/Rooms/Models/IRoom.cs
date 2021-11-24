using Starlight.API.Communication.Messages;
using Starlight.API.Game.Rooms.Component;
using Starlight.API.Game.Rooms.Entities;
using Starlight.API.Game.Rooms.Layout;
using Starlight.API.Game.Session.Models;
using System.Threading.Tasks;

namespace Starlight.API.Game.Rooms.Models
{
	public interface IRoom
	{
		IRoomData RoomData { get; }
		IRoomModel RoomModel { get; }
		IRoomMap RoomMap { get; }

		IEntityComponent Entity { get; }

		void AddPlayerEntity(ISession session);
		Task SendMessageAsync(MessageComposer packet);
	}
}
