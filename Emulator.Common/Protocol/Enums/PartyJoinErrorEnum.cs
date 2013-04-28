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
    public enum PartyJoinErrorEnum
    {
        PARTY_JOIN_ERROR_UNKNOWN = 0,
        PARTY_JOIN_ERROR_PLAYER_NOT_FOUND = 1,
        PARTY_JOIN_ERROR_PARTY_NOT_FOUND = 2,
        PARTY_JOIN_ERROR_PARTY_FULL = 3,
        PARTY_JOIN_ERROR_PLAYER_BUSY = 4,
        PARTY_JOIN_ERROR_PLAYER_ALREADY_INVITED = 6,
        PARTY_JOIN_ERROR_PLAYER_TOO_SOLLICITED = 7,
        PARTY_JOIN_ERROR_PLAYER_LOYAL = 8,
        PARTY_JOIN_ERROR_UNMODIFIABLE = 9,
        PARTY_JOIN_ERROR_UNMET_CRITERION = 10,
    }
}