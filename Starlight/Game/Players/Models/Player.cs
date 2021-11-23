using Starlight.API.Game.Players.Components;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Components;

namespace Starlight.Game.Players.Models
{
    internal class Player : IPlayer
    {
        public IPlayerData PlayerData { get; }
        public ISession Session { get; }

        public IPlayerSettings PlayerSettings { get; set; }
        public IMessengerComponent MessengerComponent { get; set; }

        internal Player(IPlayerData data, ISession session)
        {
            PlayerData = data;
            Session = session;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            MessengerComponent = new MessengerComponent(this);
        }
    }
}
