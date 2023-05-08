# LuzFaltex.Permissions

This library sets the groundwork for a role-based permission system for [ObsidianMC](https://github.com/ObsidianMC/Obsidian). As Obsidian is still in a pre-release state, this plugin may not have all of the features and may experience breakage as things change with the Obsidian API. At this time, use of this plugin in a production environment is not recommended nor supported by *LuzFaltex*.

## Purpose

This library is designed to provide a granular permissions system, much like [PermissionsEx](https://permissionsex.stellardrift.ca/) and [LuckPerms](https://luckperms.net/) for the Java world. We aim to provide the following:

* Role-Based Access Control. No futzing with power levels. Users simply inherit all permissions from any groups they are a member of.
* Granular, node-based permissions, just like Minecraft of old.
* Explicit wildcard nodes. `MyPlugin.PermissionGroup.*` will grant all permissions starting with `MyPlugin.PermissionGroup.`.
* A flexible API interface for developers who wish to integrate with LuzFaltex.Permissions. This is not required for providing permission nodes, but may be useful for complex scenarios such as syncing roles between servers or programmatically modifying groups and group membership. 