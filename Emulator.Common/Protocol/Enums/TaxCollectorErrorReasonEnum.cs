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
    public enum TaxCollectorErrorReasonEnum
    {
        TAX_COLLECTOR_ERROR_UNKNOWN = 0,
        TAX_COLLECTOR_NOT_FOUND = 1,
        TAX_COLLECTOR_NOT_OWNED = 2,
        TAX_COLLECTOR_NO_RIGHTS = 3,
        TAX_COLLECTOR_MAX_REACHED = 4,
        TAX_COLLECTOR_ALREADY_ONE = 5,
        TAX_COLLECTOR_CANT_HIRE_YET = 6,
        TAX_COLLECTOR_CANT_HIRE_HERE = 7,
        TAX_COLLECTOR_NOT_ENOUGH_KAMAS = 8,
    }
}