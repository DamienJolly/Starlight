using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class MarketplaceConfigurationComposer : MessageComposer
    {
        public MarketplaceConfigurationComposer() : base(Headers.MarketplaceConfigurationComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
			//Todo: Catalog marketplace
			message.WriteBoolean(true); // Dunno?
			message.WriteInt(1); // Commission percent.
            message.WriteInt(10); // Credits
			message.WriteInt(5); // Advertisements
			message.WriteInt(1); // Min price
			message.WriteInt(99999999); // Max price.
			message.WriteInt(48); // Hours in marketplace
			message.WriteInt(7); // Days to display
        }
    }
}
