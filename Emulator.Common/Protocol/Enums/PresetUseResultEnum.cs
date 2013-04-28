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
    public enum PresetUseResultEnum
    {
        PRESET_USE_OK = 1,
        PRESET_USE_OK_PARTIAL = 2,
        PRESET_USE_ERR_UNKNOWN = 3,
        PRESET_USE_ERR_CRITERION = 4,
        PRESET_USE_ERR_BAD_PRESET_ID = 5,
    }
}