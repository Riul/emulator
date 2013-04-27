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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Authorized
{
    public class ConsoleCommandsListMessage : NetworkMessage
    {
        public const uint Id = 6127;

        public string[] aliases;
        public string[] arguments;
        public string[] descriptions;


        public ConsoleCommandsListMessage()
        {
        }

        public ConsoleCommandsListMessage(string[] aliases, string[] arguments, string[] descriptions)
        {
            this.aliases = aliases;
            this.arguments = arguments;
            this.descriptions = descriptions;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) aliases.Length);
            foreach (var entry in aliases)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) arguments.Length);
            foreach (var entry in arguments)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort) descriptions.Length);
            foreach (var entry in descriptions)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            aliases = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                aliases[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            arguments = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                arguments[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            descriptions = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                descriptions[i] = reader.ReadUTF();
            }
        }
    }
}