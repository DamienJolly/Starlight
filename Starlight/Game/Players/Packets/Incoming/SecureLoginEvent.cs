using Starlight.API.Communication.Messages;
using Starlight.API.Game.Players;
using Starlight.API.Game.Players.Models;
using Starlight.API.Game.Session.Models;
using Starlight.Game.Players.Models;
using Starlight.Game.Players.Packets.Incoming.Args;
using Starlight.Game.Players.Packets.Outgoing;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Packets.Incoming
{
	public class SecureLoginEvent : AbstractMessageEvent<LoginArgs>
	{
		public override short Header => Headers.SecureLoginEvent;

		private readonly IPlayerController _playerController;

		public SecureLoginEvent(IPlayerController playerController)
		{
			_playerController = playerController;
		}

		protected override async ValueTask Execute(ISession session, LoginArgs args)
		{
			IPlayerData playerData = await _playerController.GetPlayerDataBySso(args.AuthTicket);
			if (playerData == null)
			{
				await session.Disconnect();
				return;
			}

			if (_playerController.TryGetPlayer(playerData.Id, out IPlayer currentPlayer)) await currentPlayer.Session.Disconnect();

			IPlayer player = new Player(playerData, session);
			session.Player = player;

			player.PlayerSettings = await _playerController.GetPlayerSettingsById(player.PlayerData.Id);

			await session.WriteAndFlushAsync(new AuthenticationOkComposer());
			await session.WriteAndFlushAsync(new HomeRoomComposer(1));
			//await session.WriteAndFlushAsync(new MinimailCountComposer(0));
			//await session.WriteAndFlushAsync(new FavouriteRoomsComposer());
			await session.WriteAndFlushAsync(new FigureSetIdsComposer());
			await session.WriteAndFlushAsync(new UserRightsComposer(session.Player.PlayerData.Rank));
			await session.WriteAndFlushAsync(new AvailabilityStatusComposer());
			//await session.WriteAndFlushAsync(new EnableNotificationsComposer(true));
			await session.WriteAndFlushAsync(new BuildersClubMembershipComposer());

			await session.WriteAndFlushAsync(new CfhTopicsInitComposer());

			//await session.WriteAndFlushAsync(new BadgeDefinitionsComposer());

			if (!_playerController.TryAddPlayer(player))
			{
				await session.Disconnect();
				return;
			}
		}
	}
}