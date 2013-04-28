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