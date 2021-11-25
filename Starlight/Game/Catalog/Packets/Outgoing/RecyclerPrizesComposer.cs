using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Catalog.Packets.Outgoing
{
    public class RecyclerPrizesComposer : MessageComposer
    {
        public RecyclerPrizesComposer() : base(Headers.RecyclerPrizesComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
			//Todo: Catalog recycler
			message.WriteInt(0); // Levels count
			{
				//message.WriteInt(0); // Level id
				//message.WriteInt(0); // Level rarity
				//message.WriteInt(0); // Prizes count
				{
					//message.WriteString(""); // Item name
					//message.WriteInt(1); // Dunno??
					//message.WriteString("s"); // Item type
					//message.WriteInt(0); // Item sprite id
				}
			}
		}
	}
}
