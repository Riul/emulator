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
    public enum DialogTypeEnum
    {
        DIALOG_BOOK = 0,
        DIALOG_DIALOG = 1,
        DIALOG_LOCKABLE = 2,
        DIALOG_PURCHASABLE = 3,
        DIALOG_GUILD_INVITATION = 4,
        DIALOG_GUILD_CREATE = 5,
        DIALOG_GUILD_RENAME = 6,
        DIALOG_MARRIAGE = 7,
        DIALOG_DUNGEON_MEETING = 8,
        DIALOG_SPELL_FORGET = 9,
        DIALOG_TELEPORTER = 10,
        DIALOG_EXCHANGE = 11,
    }
}