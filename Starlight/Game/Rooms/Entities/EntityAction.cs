using Starlight.API.Game.Rooms.Entities.Models;
using Starlight.Utils.Extensions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Game.Rooms.Entities.Models
{
    public class EntityAction : IEntityAction
    {
        private readonly ConcurrentDictionary<string, string> _activeStatuses;

        public EntityAction()
        {
            _activeStatuses = new ConcurrentDictionary<string, string>();
        }

        public void AddStatus(string key, string value)
        {
            RemoveStatus(key);
            _activeStatuses.TryAdd(key, value);
        }

        public void RemoveStatus(string key)
        {
            if (_activeStatuses.ContainsKey(key))
                _activeStatuses.Remove(key);
        }

        public bool HasStatus(string key) =>
            _activeStatuses.ContainsKey(key);

        public string StatusToString()
        {
            StringBuilder builder = new StringBuilder("/");
            foreach (var status in _activeStatuses)
            {
                builder.Append(status.Key);

                if (status.Value.Length > 0)
                {
                    builder.Append(" ");
                    builder.Append(status.Value);
                }

                builder.Append("/");
            }
            builder.Append("/");
            return builder.ToString();
        }
    }
}
