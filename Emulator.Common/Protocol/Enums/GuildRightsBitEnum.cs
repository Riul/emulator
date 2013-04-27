#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:48
// */
#endregion
namespace Emulator.Common.Protocol.Enums
{
    public enum GuildRightsBitEnum
    {
        GUILD_RIGHT_NONE = 0,
        GUILD_RIGHT_BOSS = 1,
        GUILD_RIGHT_MANAGE_GUILD_BOOSTS = 2,
        GUILD_RIGHT_MANAGE_RIGHTS = 4,
        GUILD_RIGHT_INVITE_NEW_MEMBERS = 8,
        GUILD_RIGHT_BAN_MEMBERS = 16,
        GUILD_RIGHT_MANAGE_XP_CONTRIBUTION = 32,
        GUILD_RIGHT_MANAGE_RANKS = 64,
        GUILD_RIGHT_HIRE_TAX_COLLECTOR = 128,
        GUILD_RIGHT_MANAGE_MY_XP_CONTRIBUTION = 256,
        GUILD_RIGHT_COLLECT = 512,
        GUILD_RIGHT_USE_PADDOCKS = 4096,
        GUILD_RIGHT_ORGANIZE_PADDOCKS = 8192,
        GUILD_RIGHT_TAKE_OTHERS_MOUNTS_IN_PADDOCKS = 16384,
        GUILD_RIGHT_DEFENSE_PRIORITY = 32768,
        GUILD_RIGHT_COLLECT_MY_TAX_COLLECTOR = 65536,
    }
}