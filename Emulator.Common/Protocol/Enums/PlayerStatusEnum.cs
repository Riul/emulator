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
// Created on 28/04/2013 at 11:04

#endregion

namespace Emulator.Common.Protocol.Enums
{
    public enum PlayerStatusEnum
    {
        PLAYER_STATUS_OFFLINE = 0,
        PLAYER_STATUS_UNKNOWN = 1,
        PLAYER_STATUS_AVAILABLE = 10,
        PLAYER_STATUS_IDLE = 20,
        PLAYER_STATUS_AFK = 21,
        PLAYER_STATUS_PRIVATE = 30,
        PLAYER_STATUS_SOLO = 40,
    }
}