using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Items.Models;
using Starlight.API.Game.Rooms.Models;

namespace Starlight.Game.Items.Models
{
	public class Item : IItem
	{
		public uint Id { get; set; }
		public uint ItemId { get; set; }
		public uint PlayerId { get; set; }
		public string PlayerUsername { get; set; }
		public uint RoomId { get; set; }
		public int Rot { get; set; }
		public string ExtraData { get; set; }
		public string WiredData { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public double Z { get; set; }
		public string WallCord { get; set; }
		public int GroupId { get; set; }
		public bool BuildersItem { get; set; }
		public int LimitedNum { get; set; }
		public int LimitedStack { get; set; }

		public IItemData ItemData { get; set; }
		public IRoom CurrentRoom { get; set; } = null;

		public bool IsLimited => LimitedNum > 0;

		public void ComposeFloorItem(IServerMessage message)
		{
			message.WriteInt((int)Id);
			message.WriteInt((int)ItemData.SpriteId);
			message.WriteInt(X);
			message.WriteInt(Y);
			message.WriteInt(Rot);
			message.WriteString(string.Format("{0:0.00}", Z.ToString()));
			message.WriteString("");

			message.WriteInt(IsLimited ? 1 : 0);

			message.WriteInt(0 + (IsLimited ? 256 : 0));
			message.WriteString(ExtraData);

			if (IsLimited)
			{
				message.WriteInt(LimitedNum);
				message.WriteInt(LimitedStack);
			}

			message.WriteInt(-1);
			message.WriteInt(ItemData.Modes > 1 ? 1 : 0);
			message.WriteInt(!BuildersItem ? (int)PlayerId : -12345678);
		}

		public void ComposeWallItem(IServerMessage message)
		{
			message.WriteString(Id + "");
			message.WriteInt((int)ItemData.SpriteId);
			message.WriteString(WallCord);
			message.WriteString(ExtraData);
			message.WriteInt(-1);
			message.WriteInt(ItemData.Modes > 1 ? 1 : 0);
			message.WriteInt(!BuildersItem ? (int)PlayerId : -12345678);
		}
	}
}