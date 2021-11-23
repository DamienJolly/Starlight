using System.Collections.Generic;

namespace Starlight.API.Config.Configs
{
    public abstract class AbstractConfig
    {
        public abstract string Name { get; }

        private readonly IDictionary<string, string> _fields;

        protected AbstractConfig()
        {
            _fields = new Dictionary<string, string>();
        }

        public void SetPropertyValues(string[] lines)
        {
            foreach (string line in lines)
            {
                string item = line.Split("=")[0];
                string value = line.Split("=")[1];

                if (_fields.ContainsKey(item))
                    continue;

                _fields.Add(item, value);
            }
        }

        public string GetString(string item)
        {
			_fields.TryGetValue(item, out string value);
			return value;
        }

        public int GetInt(string item)
        {
            _fields.TryGetValue(item, out string value);
            int.TryParse(value, out int number);
            return number;
        }
    }
}
