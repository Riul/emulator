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
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Messages;

namespace Emulator.Common.Protocol.Net
{
    public static class MessageBuilder
    {
        private static Dictionary<uint, Type> messages;
        private static bool initialized;

        public static NetworkMessage Build(BigEndianReader stream)
        {
            ushort header = stream.ReadUShort();
            uint id = (uint) header >> 2;
            int lenght = GetMessageLenght(stream, header);

            if (id > int.MinValue)
            {
                byte[] buffer = (lenght > 0) ? stream.ReadBytes(lenght) : new byte[] {};
                return Build(id, new BigEndianReader(buffer));
            }
            throw new Exception("Invalid packet id : " + id);
        }

        public static NetworkMessage Build(uint id, BigEndianReader data)
        {
            if (!initialized) Init();

            if (messages.ContainsKey(id))
            {
                NetworkMessage message = (NetworkMessage) Activator.CreateInstance(messages[id]);
                message.Data = data.Data;
                message.Deserialize(data);
                return message;
            }
            return new UnknowMessage(id);
        }

        private static void Init()
        {
            if (initialized) return;

            messages = new Dictionary<uint, Type>();

            Assembly assembly = Assembly.GetAssembly(typeof (NetworkMessage));
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof (NetworkMessage)))
                {
                    FieldInfo fieldId = type.GetField("Id");
                    if (fieldId != null)
                    {
                        uint id = (uint) fieldId.GetValue(type);
                        if (messages.ContainsKey(id))
                        {
                            throw new AmbiguousMatchException(string.Format("The message with id {0} is already registered.", id));
                        }
                        messages.Add(id, type);
                    }
                }
            }
            initialized = true;
        }

        private static int GetMessageLenght(BigEndianReader data, ushort read)
        {
            switch (read & 3)
            {
                case 1:
                    return data.ReadByte();
                case 2:
                    return data.ReadUShort();
                case 3:
                    return (data.ReadByte() << 16) + (data.ReadByte() << 8) + data.ReadByte();
                default:
                    return 0;
            }
        }
    }
}