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
//     Created on 26/04/2013 at 17:44
// */
#endregion

using System;

namespace Emulator.Common.Network.Dispatching
{
    public class MessageHandlerAttribute : Attribute
    {
        public MessageHandlerAttribute(Type type)
        {
            MessageType = type;
        }

        public MessageHandlerAttribute(uint id)
        {
            MessageId = id;
        }

        public Type MessageType { get; private set; }
        public uint MessageId { get; private set; }
    }
}
