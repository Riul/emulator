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
// Created on 26/04/2013 at 17:58
#endregion

using System.Reflection;
using Emulator.Common.Protocol.Net.Messages;

namespace Emulator.Common.Network.Dispatching
{
    public class MethodHandler
    {
        public MethodInfo Method { get; private set; }
        public object Instance { get; private set; }
        public MessageHandlerAttribute[] Attributes { get; private set; }

        public MethodHandler(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            Method = method;
            Instance = instance;
            Attributes = attributes;
        }

        public void Invoke(NetworkMessage message)
        {
            Method.Invoke(Instance, new object[] { message });
        }
    }
}
