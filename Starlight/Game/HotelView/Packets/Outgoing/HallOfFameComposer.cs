using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.HotelView.Models;
using System.Collections.Generic;

namespace Starlight.Game.HotelView.Packets.Outgoing
{
    public class HallOfFameComposer : MessageComposer
    {
        private readonly IList<IHallOfFamer> HallOfFamers;
        private readonly string Name;

        public HallOfFameComposer(IList<IHallOfFamer> hallOfFamers, string name) : base(Headers.HallOfFameComposer)
        {
            HallOfFamers = hallOfFamers;
            Name = name;
        }

        public override void Compose(IServerMessage packet)
        {
            packet.WriteString(Name);
            packet.WriteInt(HallOfFamers.Count);

            int count = 1;
            foreach (IHallOfFamer hallOfFamer in HallOfFamers)
            {
                packet.WriteInt(hallOfFamer.Id);
                packet.WriteString(hallOfFamer.Username);
                packet.WriteString(hallOfFamer.Figure);
                packet.WriteInt(count);
                packet.WriteInt(hallOfFamer.Amount);
                count++;
            }
        }
    }
}
