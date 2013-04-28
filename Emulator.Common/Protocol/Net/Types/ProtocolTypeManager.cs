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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Emulator.Common.Protocol.Net.Types
{
    internal class ProtocolTypeManager
    {
        private static Dictionary<int, Type> types;
        private static bool initialized;

        public static T GetInstance<T>(short id) where T : class
        {
            if (!initialized)
                Init();
            if (!types.ContainsKey(id))
                throw new Exception("Unknow Protocol Type id " + id);

            return Activator.CreateInstance(types[id]) as T;
        }

        private static void Init()
        {
            if (initialized) return;
            types = new Dictionary<int, Type>();

            Assembly assembly = Assembly.GetAssembly(typeof(ProtocolTypeManager));

            foreach (var type in assembly.GetTypes())
            {
                if (type.Namespace != null && type.Namespace.Contains("Oktopus.Dofus.Net.Types"))
                {
                    FieldInfo fieldId = type.GetField("Id");
                    if (fieldId != null)
                    {
                        short id = (short)fieldId.GetValue(type);
                        if (types.ContainsKey(id))
                        {
                            throw new AmbiguousMatchException(string.Format("The message with id {0} is already registered.", id));
                        }
                        types.Add(id, type);
                    }
                }
            }
            initialized = true;
        }
    }
}