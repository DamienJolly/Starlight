using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class DiscountComposer : MessageComposer
    {
		private static readonly int MAXIMUM_ALLOWED_ITEMS = 100;
		private static readonly int DISCOUNT_BATCH_SIZE = 6;
		private static readonly int DISCOUNT_AMOUNT_PER_BATCH = 1;
		private static readonly int MINIMUM_DISCOUNTS_FOR_BONUS = 1;
		private static readonly int[] ADDITIONAL_DISCOUNT_THRESHOLDS = new int[] { 40, 99 };

		public DiscountComposer() : base(Headers.DiscountComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
			message.WriteInt(MAXIMUM_ALLOWED_ITEMS);
			message.WriteInt(DISCOUNT_BATCH_SIZE);
			message.WriteInt(DISCOUNT_AMOUNT_PER_BATCH);
			message.WriteInt(MINIMUM_DISCOUNTS_FOR_BONUS);

			message.WriteInt(ADDITIONAL_DISCOUNT_THRESHOLDS.Length);
			foreach (int threshold in ADDITIONAL_DISCOUNT_THRESHOLDS)
			{
				message.WriteInt(threshold);
			}
        }
    }
}
