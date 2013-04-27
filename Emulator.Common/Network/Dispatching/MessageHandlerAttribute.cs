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
// Created on 26/04/2013 at 17:44
#endregion

using System;

namespace Emulator.Common.Network.Dispatching
{
    public class MessageHandlerAttribute : Attribute
    {
        public Type MessageType { get; private set; }
        public uint MessageId { get; private set; }

        public MessageHandlerAttribute(Type type)
        {
            MessageType = type;
        }

        public MessageHandlerAttribute(uint id)
        {
            MessageId = id;
        }
    }
}
