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
    public enum GuildCreationResultEnum
    {
        GUILD_CREATE_OK = 1,
        GUILD_CREATE_ERROR_NAME_INVALID = 2,
        GUILD_CREATE_ERROR_ALREADY_IN_GUILD = 3,
        GUILD_CREATE_ERROR_NAME_ALREADY_EXISTS = 4,
        GUILD_CREATE_ERROR_EMBLEM_ALREADY_EXISTS = 5,
        GUILD_CREATE_ERROR_LEAVE = 6,
        GUILD_CREATE_ERROR_CANCEL = 7,
        GUILD_CREATE_ERROR_REQUIREMENT_UNMET = 8,
        GUILD_CREATE_ERROR_EMBLEM_INVALID = 9,
    }
}