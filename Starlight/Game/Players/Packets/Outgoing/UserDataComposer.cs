using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class UserDataComposer : MessageComposer
    {
        private readonly IPlayer Player;

        public UserDataComposer(IPlayer player) : base(Headers.UserDataComposer)
        {
            Player = player;
        }

		public override void Compose(IServerMessage message)
		{
            message.WriteInt(Player.PlayerData.Id);
            message.WriteString(Player.PlayerData.Username);
            message.WriteString(Player.PlayerData.Figure);
            message.WriteString(Player.PlayerData.Gender.ToLower() == "m" ? "m" : "f");
            message.WriteString(Player.PlayerData.Motto);
            message.WriteString("");
            message.WriteBoolean(false);
            message.WriteInt(0); //Respect recieved
            message.WriteInt(0); //DailyRespect
            message.WriteInt(0); //DailyPetRespect
            message.WriteBoolean(false); //Friendstream
            message.WriteString("01.01.1970 00:00:00"); //Last online
            message.WriteBoolean(false); //Can change name
            message.WriteBoolean(false); //Safatey locked
        }
	}
}
