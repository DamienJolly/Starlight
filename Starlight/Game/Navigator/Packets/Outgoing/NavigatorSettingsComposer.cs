using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Players.Models;

namespace Starlight.Game.Navigator.Packets.Outgoing
{
    public class NavigatorSettingsComposer : MessageComposer
    {
        private readonly IPlayerSettings Settings;

        public NavigatorSettingsComposer(IPlayerSettings settings) : base(Headers.NavigatorSettingsComposer)
        {
            Settings = settings;
        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(Settings.NaviX);
            message.WriteInt(Settings.NaviY);
            message.WriteInt(Settings.NaviWidth);
            message.WriteInt(Settings.NaviHeight);
            message.WriteBoolean(Settings.NaviHideSearches);
            message.WriteInt(0); //dunno??
        }
    }
}
