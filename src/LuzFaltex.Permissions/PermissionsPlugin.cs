//
//  PermissionsPlugin.cs
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

using System.Threading.Tasks;
using JetBrains.Annotations;
using Obsidian.API;
using Obsidian.API.Events;
using Obsidian.API.Plugins;
using Obsidian.API.Plugins.Services;

#pragma warning disable SA1206

#if NETSTANDARD || NET6_0
#pragma warning disable CA2252 // False positive error. Feature is already enabled, but the analyzer does not detect this on .NET 6 and earlier.
#endif

namespace LuzFaltex.Permissions
{
    /// <summary>
    /// Defines the entry point for this plugin.
    /// </summary>
    [Plugin
    (
        name: "PermissionsLF",
        Authors = "LuzFaltex Contributors",
        Description = "Provides advanced RBAC-based permissioning to Obsidian servers.",
        ProjectUrl = "https://github.com/ravenrockrp/LuzFaltex.Permissions",
        Version = "0.1.0"
    )]
    public sealed class PermissionsPlugin : PluginBase
    {
        /// <summary>
        /// Gets a logger for this instance.
        /// </summary>
        [Inject] public ILogger Logger { private get; init; } = default!;
    }
}
