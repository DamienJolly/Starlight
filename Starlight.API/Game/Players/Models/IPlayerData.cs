namespace Starlight.API.Game.Players.Models
{
    public interface IPlayerData
    {
        /// <summary>
        /// The unique Id associated with the player.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// The players rank.
        /// </summary>
        int Rank { get; set; }

        /// <summary>
        /// The username associated with the player.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The figure of the avatar.
        /// </summary>
        string Figure { get; set; }

        /// <summary>
        /// The gender of the player.
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// The motto of the player.
        /// </summary>
        string Motto { get; set; }

        /// <summary>
        /// The credits of the player.
        /// </summary>
        int Credits { get; set; }
    }
}
