using Starlight.API.Game.Messenger.Models;

namespace Starlight.Game.Messenger.Models
{
	public class MessengerCategory : IMessengerCategory
    {
        public uint PlayerId { get; }
        public string Name { get; set; }
    }
}
