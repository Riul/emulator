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
    public enum ChatErrorEnum
    {
        CHAT_ERROR_UNKNOWN = 0,
        CHAT_ERROR_RECEIVER_NOT_FOUND = 1,
        CHAT_ERROR_INTERIOR_MONOLOGUE = 2,
        CHAT_ERROR_NO_GUILD = 3,
        CHAT_ERROR_NO_PARTY = 4,
        CHAT_ERROR_ALIGN = 5,
        CHAT_ERROR_INVALID_MAP = 6,
        CHAT_ERROR_NO_PARTY_ARENA = 7,
        CHAT_ERROR_NO_TEAM = 8,
    }
}