using Starlight.API.Game.Rooms.Models;
namespace Starlight.Game.Rooms.Models
{
    internal class RoomData : IRoomData
    {
        public uint Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Password { get; set; }
        public string ModelName { get; set; }
        public int MaxUsers { get; set; }
        public int CategoryId { get; set; }
        public int TradeType { get; set; }
        public int Score { get; set; }
    }
}
