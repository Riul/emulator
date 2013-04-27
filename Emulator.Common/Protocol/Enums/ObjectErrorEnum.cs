#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 26/04/2013 at 16:48
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