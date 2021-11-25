using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using System.Collections.Generic;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class GiftWrappingConfigurationComposer : MessageComposer
    {
		private static readonly IList<int> BOX_TYPES = new List<int> { 0, 1, 2, 3, 4, 5, 6, 8 };
		private static readonly IList<int> RIBBON_TYPES = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

		public GiftWrappingConfigurationComposer() : base(Headers.GiftWrappingConfigurationComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
			//Todo: Catalog gifts
			message.WriteBoolean(true); // Gifts enabled
			message.WriteInt(1); // Price?

			message.WriteInt(0); // Wrappers count
			{
				//message.WriteInt(0); // Sprite id
			}

			message.WriteInt(BOX_TYPES.Count);
			foreach (int boxType in BOX_TYPES)
			{
				message.WriteInt(boxType);
			}

			message.WriteInt(RIBBON_TYPES.Count);
			foreach (int ribbonType in RIBBON_TYPES)
			{
				message.WriteInt(ribbonType);
			}

			message.WriteInt(0); // Gifts count
			{
				//message.WriteInt(0); // Sprite id
			}
        }
    }
}
