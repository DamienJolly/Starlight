namespace Starlight.API.Game.Items.Models
{
	public interface IItemData
	{
		uint Id { get; }
		uint SpriteId { get; }
		string Name { get; }
		int Length { get; }
		int Width { get; }
		double Height { get; }
		string ExtraData { get; }
		string Type { get; }
		int Modes { get; }
		bool CanWalk { get; set; }
		bool CanSit { get; }
		bool CanLay { get; set; }
		bool CanStack { get; }
		bool AllowRecycle { get; }
		bool AllowTrade { get; }
		bool AllowInventoryStack { get; }
		bool AllowMarketplace { get; }
		int EffectId { get; }
		string InteractionType { get; }
	}
}