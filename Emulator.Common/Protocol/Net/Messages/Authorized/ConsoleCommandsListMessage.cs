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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Authorized
{
    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const uint ID = 6127;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string[] Aliases { get; set; }
        public string[] Arguments { get; set; }
        public string[] Descriptions { get; set; }


        public ConsoleCommandsListMessage()
        {
        }

        public ConsoleCommandsListMessage(string[] aliases, string[] arguments, string[] descriptions)
        {
            Aliases = aliases;
            Arguments = arguments;
            Descriptions = descriptions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Aliases.Length);
            foreach (var entry in Aliases)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) Arguments.Length);
            foreach (var entry in Arguments)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) Descriptions.Length);
            foreach (var entry in Descriptions)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Aliases = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                Aliases[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            Arguments = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                Arguments[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            Descriptions = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                Descriptions[i] = reader.ReadUTF();
            }
        }
    }
}