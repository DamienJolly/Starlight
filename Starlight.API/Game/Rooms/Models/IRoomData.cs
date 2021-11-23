namespace Starlight.API.Game.Rooms.Models
{
	public interface IRoomData
	{
        uint Id { get; set; }
        int OwnerId { get; set; }
        string OwnerName { get; set; }
        string Name { get; set; }
        string Caption { get; set; }
        string Password { get; set; }
        string ModelName { get; set; }
        int MaxUsers { get; set; }
        int CategoryId { get; set; }
        int TradeType { get; set; }
        int Score { get; set; }
    }
}
