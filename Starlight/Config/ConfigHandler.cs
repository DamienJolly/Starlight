using Microsoft.Extensions.Logging;
using Starlight.API.Config;
using Starlight.API.Config.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Starlight.Config
{
	public class ConfigHandler : IConfigHandler
	{
		private readonly ILogger<ConfigHandler> _logger;
		private readonly IDictionary<string, AbstractConfig> _configs;

		public ConfigHandler(ILogger<ConfigHandler> logger, IEnumerable<AbstractConfig> servers)
		{
			_logger = logger;

			_configs = servers.ToDictionary(config => config.Name);
			InitializeConfigs();

			_logger.LogInformation("Loaded {0} configuration files", _configs.Count);
		}

		private void InitializeConfigs()
		{
			foreach (AbstractConfig config in _configs.Values)
			{
				string[] lines = ReadFile(config.Name);
				config.SetPropertyValues(lines);
			}
		}

		private string[] ReadFile(string fileName)
		{
			string path = Environment.CurrentDirectory + $@"/config/{fileName}.config";
			if (File.Exists(path))
			{
				return File.ReadAllLines(path);
			}

			throw new Exception("File doesn't exist!");
		}

		public TConfig Get<TConfig>(string name) where TConfig : AbstractConfig
		{
			if (_configs.TryGetValue(name, out AbstractConfig config))
			{
				return (TConfig)config;
			}

			return null;
		}
	}
}