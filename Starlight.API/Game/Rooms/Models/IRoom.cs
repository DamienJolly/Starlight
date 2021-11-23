namespace Starlight.API.Game.Rooms.Models
{
	public interface IRoom
	{
		IRoomData RoomData { get; }
		IRoomModel RoomModel { get; }
	}
}
