namespace Starlight.API.Game.Players.Models
{
    public interface IPlayerSettings
    {
        /// <summary>
        /// The prefered X coordinate for the navigator.
        /// </summary>
        int NaviX { get; set; }

        /// <summary>
        /// The prefered Y coordinate for the navigator.
        /// </summary>
        int NaviY { get; set; }

        /// <summary>
        /// The prefered width for the navigator.
        /// </summary>
        int NaviWidth { get; set; }

        /// <summary>
        /// The prefered height for the navigator.
        /// </summary>
        int NaviHeight { get; set; }

        /// <summary>
        /// Wether or not you want to show the saved searches by default.
        /// </summary>
        bool NaviHideSearches { get; set; }

        /// <summary>
        /// Wether or not you want to ignore messenger invites.
        /// </summary>
        bool IgnoreInvites { get; set; }

        /// <summary>
        /// Wether or not you want to ignore photo following.
        /// </summary>
        bool CameraFollow { get; set; }

        /// <summary>
        /// Wether or not you prefer old chat style.
        /// </summary>
        bool OldChat { get; set; }

        /// <summary>
        /// The players set system volume.
        /// </summary>
        int VolumeSystem { get; set; }

        /// <summary>
        /// The players set furniture volume.
        /// </summary>
        int VolumeFurni { get; set; }

        /// <summary>
        /// The players set trax volume.
        /// </summary>
        int VolumeTrax { get; set; }
    }
}
