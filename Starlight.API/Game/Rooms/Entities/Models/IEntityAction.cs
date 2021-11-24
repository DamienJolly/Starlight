namespace Starlight.API.Game.Rooms.Entities.Models
{
	public interface IEntityAction
	{
		void AddStatus(string key, string value);

		void RemoveStatus(string key);

		bool HasStatus(string key);

		string StatusToString();
	}
}
