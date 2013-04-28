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
    public enum ExchangeErrorEnum
    {
        REQUEST_IMPOSSIBLE = 1,
        REQUEST_CHARACTER_OCCUPIED = 2,
        REQUEST_CHARACTER_JOB_NOT_EQUIPED = 3,
        REQUEST_CHARACTER_TOOL_TOO_FAR = 4,
        REQUEST_CHARACTER_OVERLOADED = 5,
        REQUEST_CHARACTER_NOT_SUSCRIBER = 6,
        REQUEST_CHARACTER_RESTRICTED = 7,
        BUY_ERROR = 8,
        SELL_ERROR = 9,
        MOUNT_PADDOCK_ERROR = 10,
        BID_SEARCH_ERROR = 11,
    }
}