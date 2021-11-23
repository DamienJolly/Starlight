using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class PlayerSettingsComposer : MessageComposer
    {
        private readonly IPlayerSettings PlayerSettings;

        public PlayerSettingsComposer(IPlayerSettings playerSettings) : base(Headers.PlayerSettingsComposer)
        {
            PlayerSettings = playerSettings;
        }

		public override void Compose(IServerMessage message)
		{
            message.WriteInt(PlayerSettings.VolumeSystem);
            message.WriteInt(PlayerSettings.VolumeFurni);
            message.WriteInt(PlayerSettings.VolumeTrax);
            message.WriteBoolean(PlayerSettings.OldChat);
            message.WriteBoolean(PlayerSettings.IgnoreInvites);
            message.WriteBoolean(PlayerSettings.CameraFollow);
            message.WriteInt(1); // dunno?
            message.WriteInt(0); // dunno?
            message.WriteInt(0); // dunno?
        }
	}
}
