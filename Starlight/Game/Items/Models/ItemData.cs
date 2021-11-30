using Starlight.API.Game.Items.Models;

namespace Starlight.Game.Items.Models
{
	public class ItemData : IItemData
	{
		public uint Id { get; }
		public uint SpriteId { get; }
		public string Name { get; }
		public int Length { get; }
		public int Width { get; }
		public double Height { get; }
		public string ExtraData { get; }
		public string Type { get; }
		public int Modes { get; }
		public bool CanWalk { get; set; }
		public bool CanSit { get; }
		public bool CanLay { get; set; }
		public bool CanStack { get; }
		public bool AllowRecycle { get; }
		public bool AllowTrade { get; }
		public bool AllowInventoryStack { get; }
		public bool AllowMarketplace { get; }
		public int EffectId { get; }
		public string InteractionType { get; }
	}
}