using Starlight.API.Game.HotelView.Models;

namespace Starlight.Game.HotelView.Models
{
    internal class HallOfFamer : IHallOfFamer
    {
        public uint Id { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
    }
}
