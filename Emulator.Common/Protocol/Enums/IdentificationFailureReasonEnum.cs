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
    public enum IdentificationFailureReasonEnum
    {
        BAD_VERSION = 1,
        WRONG_CREDENTIALS = 2,
        BANNED = 3,
        KICKED = 4,
        IN_MAINTENANCE = 5,
        TOO_MANY_ON_IP = 6,
        TIME_OUT = 7,
        BAD_IPRANGE = 8,
        CREDENTIALS_RESET = 9,
        EMAIL_UNVALIDATED = 10,
        SERVICE_UNAVAILABLE = 53,
        UNKNOWN_AUTH_ERROR = 99,
        SPARE = 100,
    }
}