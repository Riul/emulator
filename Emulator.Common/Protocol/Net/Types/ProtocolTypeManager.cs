#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:46
// */
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