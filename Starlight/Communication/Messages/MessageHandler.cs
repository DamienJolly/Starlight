﻿using Microsoft.Extensions.Logging;
using Starlight.API.Communication.Messages;
using Starlight.API.Communication.Messages.Protocols;
using Starlight.API.Game.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starlight.Communication.Messages
{
    public class MessageHandler : IMessageHandler
    {
        private readonly ILogger<MessageHandler> _logger;
        private readonly Dictionary<short, IMessageEvent> _messageEvents;

        public MessageHandler(ILogger<MessageHandler> logger, IEnumerable<IMessageEvent> messageEvents)
        {
            _logger = logger;
            _messageEvents = messageEvents.ToDictionary(messageEvent => messageEvent.Header);

            _logger.LogInformation("Loaded {0} message events", _messageEvents.Count);
        }

        public async Task TriggerEventAsync(ISession session, IClientMessage message)
        {
            try
            {
                if (_messageEvents.TryGetValue(message.Header, out IMessageEvent messageEvent))
                {
                    _logger.LogInformation("Executing {0} for header {1}", messageEvent.GetType().Name, message.Header);
                    await messageEvent.HandleAsync(session, message);
                }
                else
                {
                    _logger.LogWarning("Unregistered header {0}", message.Header);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Packet Error! \n {0}", e.ToString());
            }
        }
    }
}