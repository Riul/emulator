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
    public enum CrafterDirectoryParamBitEnum
    {
        CRAFT_OPTION_NONE = 0,
        CRAFT_OPTION_NOT_FREE = 1,
        CRAFT_OPTION_NOT_FREE_EXCEPT_ON_FAIL = 2,
        CRAFT_OPTION_RESOURCES_REQUIRED = 4,
    }
}