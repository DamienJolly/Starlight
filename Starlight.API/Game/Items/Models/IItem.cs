using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Rooms.Models;

namespace Starlight.API.Game.Items.Models
{
	public interface IItem
	{
		uint Id { get; set; }
		uint ItemId { get; set; }
		uint PlayerId { get; set; }
		string PlayerUsername { get; set; }
		uint RoomId { get; set; }
		int Rot { get; set; }
		string ExtraData { get; set; }
		string WiredData { get; set; }
		int X { get; set; }
		int Y { get; set; }
		double Z { get; set; }
		string WallCord { get; set; }
		int GroupId { get; set; }
		bool BuildersItem { get; set; }
		int LimitedNum { get; set; }
		int LimitedStack { get; set; }

		IItemData ItemData { get; set; }
		IRoom CurrentRoom { get; set; }

		bool IsLimited { get; }

		void ComposeFloorItem(IServerMessage message);

		void ComposeWallItem(IServerMessage message);
	}
}