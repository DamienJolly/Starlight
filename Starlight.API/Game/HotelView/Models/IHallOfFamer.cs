namespace Starlight.API.Game.HotelView.Models
{
    public interface IHallOfFamer
    {
        /// <summary>
        /// The user id associated with the hall of famer.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// The hall of famers amount.
        /// </summary>
        int Amount { get; set; }

        /// <summary>
        /// The hall of famers username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The hall of famers figure.
        /// </summary>
        string Figure { get; set; }
    }
}
