using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.GameCenter.Packets.Outgoing
{
    public class GameCenterAchievementsListComposer : MessageComposer
    {
        public GameCenterAchievementsListComposer() : base(Headers.GameCenterAchievementsListComposer)
        {

        }

        public override void Compose(IServerMessage message)
        {
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(0);
            message.WriteInt(3);
            message.WriteInt(1);
            message.WriteInt(1);
            message.WriteString("BaseJumpBigParachute");
            message.WriteInt(1);
        }
    }
}
