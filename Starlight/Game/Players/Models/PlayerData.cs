using Starlight.API.Game.Players.Models;

namespace Starlight.Game.Players.Models
{
    internal class PlayerData : IPlayerData
    {
        public uint Id { get; set; }
        public int Rank { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
        public string Gender { get; set; }
        public string Motto { get; set; }
        public int Credits { get; set; }
    }
}
