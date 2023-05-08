//
//  IServerEventNotification.cs
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

using MediatR;
using Obsidian.API.Events;

namespace LuzFaltex.Permissions.Notifications
{
    /// <summary>
    /// Defines a notification which represents an event in Minecraft.
    /// </summary>
    /// <typeparam name="TMinecraftEvent">The type of event.</typeparam>
    public interface IServerEventNotification<TMinecraftEvent> : INotification
        where TMinecraftEvent : BaseMinecraftEventArgs
    {
        /// <summary>
        /// Gets the event that was reported.
        /// </summary>
        public TMinecraftEvent Event { get; }

        /// <summary>
        /// Called when the event is cancelled.
        /// </summary>
        public void Cancel();
    }
}
