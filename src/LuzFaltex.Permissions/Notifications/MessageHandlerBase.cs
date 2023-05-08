//
//  MessageHandlerBase.cs
//
//  Author:
//       LuzFaltex Contributors <support@luzfaltex.com>
//
//  Copyright (c) LuzFaltex, LLC.
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Obsidian.API.Events;
using Obsidian.API.Plugins.Services;

using Stopwatch = System.Diagnostics.Stopwatch;

namespace LuzFaltex.Permissions.Notifications
{
    /// <summary>
    /// Provides a base type for notification handlers which handle Minecraft events.
    /// </summary>
    /// <typeparam name="TMinecraftEvent">The type of Minecraft event this handler is responsible for.</typeparam>
    public abstract class MessageHandlerBase<TMinecraftEvent> : INotificationHandler<IServerEventNotification<TMinecraftEvent>>
        where TMinecraftEvent : BaseMinecraftEventArgs
    {
        private readonly ILogger _logger;
        private readonly string _eventType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandlerBase{TMinecraftEvent}"/> class.
        /// </summary>
        /// <param name="logger">A logger for this instance.</param>
        /// <param name="eventType">The type of event being handled.</param>
        public MessageHandlerBase(ILogger logger, string eventType)
        {
            _logger = logger;
            _eventType = eventType;
        }

        /// <inheritdoc/>
        public async Task Handle(IServerEventNotification<TMinecraftEvent> notification, CancellationToken cancellationToken)
        {
            var minecraftEvent = notification.Event;
            if (minecraftEvent.Handled)
            {
                return;
            }
            else if (minecraftEvent is ICancellable cancellable && cancellable.Cancel)
            {
                notification.Cancel();
                await Task.FromCanceled(cancellationToken);
            }
            else
            {
                _logger.LogDebug($"Handling {_eventType} notification.");
                var sw = Stopwatch.StartNew();
                await HandleAsync(minecraftEvent, cancellationToken);
                sw.Stop();
                _logger.LogDebug($"Handled {_eventType} notification after {sw.ElapsedMilliseconds}ms.");
            }
        }

        /// <summary>
        /// Executes the handler for this event.
        /// </summary>
        /// <param name="minecraftEvent">An event from Minecraft.</param>
        /// <param name="cancellationToken">A cancellation token for this operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task HandleAsync(TMinecraftEvent minecraftEvent, CancellationToken cancellationToken);
    }
}
