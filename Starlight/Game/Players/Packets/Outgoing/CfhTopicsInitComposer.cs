using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;

namespace Starlight.Game.Players.Packets.Outgoing
{
    public class CfhTopicsInitComposer : MessageComposer
    {
        public CfhTopicsInitComposer() : base(Headers.CfhTopicsInitComposer)
        {

        }

		public override void Compose(IServerMessage packet)
		{
            packet.WriteInt(6);
            {
                packet.WriteString("sex_and_pii");
                packet.WriteInt(8);
                {
                    packet.WriteString("sexual_webcam_images");
                    packet.WriteInt(1);
                    packet.WriteString("mods");

                    packet.WriteString("sexual_webcam_images_auto");
                    packet.WriteInt(2);
                    packet.WriteString("mods");

                    packet.WriteString("explicit_sexual_talk");
                    packet.WriteInt(3);
                    packet.WriteString("mods");

                    packet.WriteString("cybersex");
                    packet.WriteInt(4);
                    packet.WriteString("mods");

                    packet.WriteString("cybersex_auto");
                    packet.WriteInt(5);
                    packet.WriteString("mods");

                    packet.WriteString("meet_some");
                    packet.WriteInt(6);
                    packet.WriteString("mods");

                    packet.WriteString("meet_irl");
                    packet.WriteInt(7);
                    packet.WriteString("mods");

                    packet.WriteString("email_or_phone");
                    packet.WriteInt(8);
                    packet.WriteString("mods");
                }

                packet.WriteString("scamming");
                packet.WriteInt(3);
                {
                    packet.WriteString("stealing");
                    packet.WriteInt(9);
                    packet.WriteString("mods");

                    packet.WriteString("scamsites");
                    packet.WriteInt(10);
                    packet.WriteString("mods");

                    packet.WriteString("selling_buying_accounts_or_furni");
                    packet.WriteInt(11);
                    packet.WriteString("mods");
                }

                packet.WriteString("trolling");
                packet.WriteInt(11);
                {
                    packet.WriteString("hate_speech");
                    packet.WriteInt(12);
                    packet.WriteString("mods");

                    packet.WriteString("violent_roleplay");
                    packet.WriteInt(13);
                    packet.WriteString("mods");

                    packet.WriteString("swearing");
                    packet.WriteInt(14);
                    packet.WriteString("auto_reply");

                    packet.WriteString("drugs");
                    packet.WriteInt(15);
                    packet.WriteString("mods");

                    packet.WriteString("gambling");
                    packet.WriteInt(16);
                    packet.WriteString("mods");

                    packet.WriteString("self_threatening");
                    packet.WriteInt(17);
                    packet.WriteString("mods");

                    packet.WriteString("mild_staff_impersonation");
                    packet.WriteInt(18);
                    packet.WriteString("mods");

                    packet.WriteString("severe_staff_impersonation");
                    packet.WriteInt(19);
                    packet.WriteString("mods");

                    packet.WriteString("habbo_name");
                    packet.WriteInt(20);
                    packet.WriteString("mods");

                    packet.WriteString("minors_access");
                    packet.WriteInt(21);
                    packet.WriteString("mods");

                    packet.WriteString("bullying");
                    packet.WriteInt(22);
                    packet.WriteString("guardians");
                }

                packet.WriteString("interruption");
                packet.WriteInt(2);
                {
                    packet.WriteString("flooding");
                    packet.WriteInt(23);
                    packet.WriteString("mods");

                    packet.WriteString("doors");
                    packet.WriteInt(24);
                    packet.WriteString("mods");
                }

                packet.WriteString("room");
                packet.WriteInt(1);
                {
                    packet.WriteString("room_report");
                    packet.WriteInt(25);
                    packet.WriteString("mods");
                }

                packet.WriteString("help");
                packet.WriteInt(2);
                {
                    packet.WriteString("help_habbo");
                    packet.WriteInt(26);
                    packet.WriteString("auto_reply");

                    packet.WriteString("help_payments");
                    packet.WriteInt(27);
                    packet.WriteString("auto_reply");
                }
            }
        }
	}
}
