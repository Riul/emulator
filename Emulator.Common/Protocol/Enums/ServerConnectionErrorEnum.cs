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
    public enum ServerConnectionErrorEnum
    {
        SERVER_CONNECTION_ERROR_DUE_TO_STATUS = 0,
        SERVER_CONNECTION_ERROR_NO_REASON = 1,
        SERVER_CONNECTION_ERROR_ACCOUNT_RESTRICTED = 2,
        SERVER_CONNECTION_ERROR_COMMUNITY_RESTRICTED = 3,
        SERVER_CONNECTION_ERROR_LOCATION_RESTRICTED = 4,
        SERVER_CONNECTION_ERROR_SUBSCRIBERS_ONLY = 5,
        SERVER_CONNECTION_ERROR_REGULAR_PLAYERS_ONLY = 6,
    }
}