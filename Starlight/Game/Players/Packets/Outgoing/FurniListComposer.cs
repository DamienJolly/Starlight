using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Items.Models;
using System.Collections.Generic;

namespace Starlight.Game.Players.Packets.Outgoing
{
	public class FurniListComposer : MessageComposer
	{
		private readonly IList<IItem> PlayerItems;

		public FurniListComposer(IList<IItem> playerItems) : base(Headers.FurniListComposer)
		{
			PlayerItems = playerItems;
		}

		public override void Compose(IServerMessage message)
		{
			message.WriteInt(1);
			message.WriteInt(0);

			message.WriteInt(PlayerItems.Count);
			foreach (IItem item in PlayerItems)
			{
				message.WriteInt(item.Id);
				message.WriteString(item.ItemData.Type.ToUpper());
				message.WriteInt(item.Id);
				message.WriteInt(item.ItemData.SpriteId);

				message.WriteInt(1);

				message.WriteInt(0 + (item.IsLimited ? 256 : 0));
				message.WriteString(item.ExtraData);

				if (item.IsLimited)
				{
					message.WriteInt(item.LimitedNum);
					message.WriteInt(item.LimitedStack);
				}

				message.WriteBoolean(item.ItemData.AllowRecycle);
				message.WriteBoolean(item.ItemData.AllowTrade);
				message.WriteBoolean(!item.IsLimited && item.ItemData.AllowInventoryStack);
				message.WriteBoolean(item.ItemData.AllowMarketplace);

				message.WriteInt(-1); //time left
				message.WriteBoolean(false); //renatable period started
				message.WriteInt(-1); //room id

				if (item.ItemData.Type == "s")
				{
					message.WriteString("");
					message.WriteInt(0);
				}
			}
		}
	}
}