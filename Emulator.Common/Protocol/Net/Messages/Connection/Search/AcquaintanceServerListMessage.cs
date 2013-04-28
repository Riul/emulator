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

namespace Emulator.Common.Protocol.Net.Messages.Connection.Search
{
    public class AcquaintanceServerListMessage : NetworkMessage
    {
        public const uint ID = 6142;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] Servers { get; set; }


        public AcquaintanceServerListMessage()
        {
        }

        public AcquaintanceServerListMessage(short[] servers)
        {
            Servers = servers;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Servers.Length);
            foreach (var entry in Servers)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Servers = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Servers[i] = reader.ReadShort();
            }
        }
    }
}