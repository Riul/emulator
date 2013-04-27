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
//     Created on 26/04/2013 at 17:58
// */
#endregion

using System.Reflection;
using Emulator.Common.Protocol.Net.Messages;

namespace Emulator.Common.Network.Dispatching
{
    public class MethodHandler
    {
        public MethodHandler(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            Method = method;
            Instance = instance;
            Attributes = attributes;
        }

        public MethodInfo Method { get; private set; }
        public object Instance { get; private set; }
        public MessageHandlerAttribute[] Attributes { get; private set; }

        public void Invoke(NetworkMessage message)
        {
            Method.Invoke(Instance, new object[] { message });
        }
    }
}
