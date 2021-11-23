using Starlight.API.Game.Players.Models;

namespace Starlight.Game.Players.Models
{
    public class PlayerSettings : IPlayerSettings
    {
        public int NaviX { get; set; }
        public int NaviY { get; set; }
        public int NaviWidth { get; set; }
        public int NaviHeight { get; set; }
        public bool NaviHideSearches { get; set; }
        public bool IgnoreInvites { get; set; }
        public bool CameraFollow { get; set; }
        public bool OldChat { get; set; }
        public int VolumeSystem { get; set; }
        public int VolumeFurni { get; set; }
        public int VolumeTrax { get; set; }
    }
}
