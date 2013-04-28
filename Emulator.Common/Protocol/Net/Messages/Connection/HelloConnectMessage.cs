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

namespace Emulator.Common.Protocol.Net.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint ID = 3;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string Salt { get; set; }
        public sbyte[] Key { get; set; }


        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            Salt = salt;
            Key = key;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteUShort((ushort) Key.Length);
            foreach (var entry in Key)
            {
                writer.WriteSByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Salt = reader.ReadUTF();
            var limit = reader.ReadUShort();
            Key = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                Key[i] = reader.ReadSByte();
            }
        }
    }
}