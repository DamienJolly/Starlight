using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Pathfinding.Models;

namespace Starlight.Game.Rooms.Entities
{
	public class PlayerEntity : BaseEntity
	{
        private readonly IPlayer _player;

        public readonly ISession Session;

        internal PlayerEntity(int id, Position position, int rotation, ISession session)
            : base(id, position, rotation, session.CurrentRoom, session.Player.PlayerData.Username, session.Player.PlayerData.Figure, session.Player.PlayerData.Gender, session.Player.PlayerData.Motto, 0)
        {
            _player = session.Player;
            Session = session;
        }

        public override void Compose(IServerMessage ServerMessage)
        {
            ServerMessage.WriteInt(_player.PlayerData.Id);
            ServerMessage.WriteString(Name);
            ServerMessage.WriteString(Motto);
            ServerMessage.WriteString(Figure);
            ServerMessage.WriteInt(Id);
            ServerMessage.WriteInt(Position.X);
            ServerMessage.WriteInt(Position.Y);
            ServerMessage.WriteDouble(Position.Z);
            ServerMessage.WriteInt(BodyRotation);

            ServerMessage.WriteInt(1);
            ServerMessage.WriteString(_player.PlayerData.Gender.ToLower() == "m" ? "m" : "f");

            // Todo: Groups
            ServerMessage.WriteInt(-1);
            ServerMessage.WriteInt(-1);
            ServerMessage.WriteString(string.Empty);

            ServerMessage.WriteString(string.Empty); // dunno?
            ServerMessage.WriteInt(Score);
            ServerMessage.WriteBoolean(true);
        }
    }
}
