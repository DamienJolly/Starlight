using Starlight.API.Game.Messenger.Models;
using Starlight.API.Game.Messenger.Types;
using Starlight.API.Game.Players.Components;
using Starlight.API.Game.Players.Models;
using Starlight.Game.Messenger.Models;
using Starlight.Game.Messenger.Packets.Outgoing;
using Starlight.Utils.Extensions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Game.Players.Components
{
	public class MessengerComponent : IMessengerComponent
    {
        private readonly IPlayer _player;

        public IList<IMessengerFriend> Friends { get; set; }
        public IList<IMessengerRequest> Requests { get; set; }
        public IList<IMessengerCategory> Categories { get; set; }
        public ConcurrentQueue<IMessengerUpdate> UpdateQueue { get; private set; }

        public MessengerComponent(IPlayer player)
        {
            _player = player;

            Friends = new List<IMessengerFriend>();
            Requests = new List<IMessengerRequest>();
            Categories = new List<IMessengerCategory>();
            UpdateQueue = new ConcurrentQueue<IMessengerUpdate>();
        }

        public void QueueUpdate(MessengerUpdateType type, IMessengerFriend friend)
        {
			UpdateQueue.Enqueue(new MessengerUpdate
            {
                UpdateType = type,
                Friend = friend
            });
        }

        public async Task ForceUpdate()
        {
            List<IMessengerUpdate> updates = UpdateQueue.Dequeue();

            await _player.Session.WriteAndFlushAsync(new FriendListUpdateComposer(Categories, updates));
        }

        public IMessengerFriend GetFriend(uint playerId) => Friends.FirstOrDefault(x => x.TargetId == playerId);

        public IMessengerRequest GetRequest(uint playerId) => Requests.FirstOrDefault(x => x.TargetId == playerId);

        public bool HasFriend(uint playerId) => Friends.Count(x => x.TargetId == playerId) > 0;

        public bool HasRequest(uint playerId) => Requests.Count(x => x.TargetId == playerId) > 0;

        public void AddFriend(IMessengerFriend friend) => Friends.Add(friend);

        public void AddRequest(IMessengerRequest request) => Requests.Add(request);

        public void RemoveFriend(uint playerId) => Friends.RemoveAll(x => x.TargetId == playerId);

        public void RemoveRequest(uint playerId) => Requests.RemoveAll(x => x.TargetId == playerId);

        public void RemoveAllRequests() => Requests.Clear();
    }
}
