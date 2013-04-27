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

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint Id = 3;

        public byte[] key;
        public string salt;


        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt, byte[] key)
        {
            this.salt = salt;
            this.key = key;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(salt);
            writer.WriteUShort((ushort) key.Length);
            foreach (var entry in key)
            {
                writer.WriteByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            salt = reader.ReadUTF();
            var limit = reader.ReadUShort();
            key = new byte[limit];
            for (int i = 0; i < limit; i++)
            {
                key[i] = reader.ReadByte();
            }
        }
    }
}