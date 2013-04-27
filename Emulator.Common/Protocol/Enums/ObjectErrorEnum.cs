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
    public enum ObjectErrorEnum
    {
        INVENTORY_FULL = 1,
        CANNOT_EQUIP_TWICE = 2,
        NOT_TRADABLE = 3,
        CANNOT_DROP = 4,
        CANNOT_DROP_NO_PLACE = 5,
        CANNOT_DESTROY = 6,
        LEVEL_TOO_LOW = 7,
        LIVING_OBJECT_REFUSED_FOOD = 8,
        CANNOT_UNEQUIP = 9,
        CANNOT_EQUIP_HERE = 10,
        CRITERIONS = 11,
    }
}