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

namespace Emulator.Common.Protocol.Net.Messages
{
    public abstract class NetworkMessage
    {
        public byte[] Data { get; set; }
        public abstract uint MessageId { get; }

        public abstract void Serialize(BigEndianWriter writer);
        public abstract void Deserialize(BigEndianReader reader);

        public void Pack(BigEndianWriter writer)
        {
            Serialize(writer);
            BuildPacket(writer);
        }

        private void BuildPacket(BigEndianWriter writer)
        {
            byte[] data = writer.Data;

            writer.Clear();

            int messageLenghtType = ComputeTypeLen(data.Length);
            short header = ComputeStaticHeader((int)MessageId, messageLenghtType);

            writer.WriteShort(header);

            switch (messageLenghtType)
            {
                case 1:
                    writer.WriteByte((byte)data.Length);
                    break;
                case 2:
                    writer.WriteShort((short)data.Length);
                    break;
                case 3:
                    writer.WriteByte((byte)(data.Length >> 16 & 255));
                    writer.WriteShort((short)(data.Length & 65535));
                    break;
            }

            writer.WriteBytes(data);
        }

        private static short ComputeStaticHeader(int packetId, int messageLenghtType)
        {
            return (short)((packetId << 2) | messageLenghtType);
        }

        private static short ComputeTypeLen(int messageLenght)
        {
            if (messageLenght > ushort.MaxValue) return 3;
            if (messageLenght > byte.MaxValue) return 2;
            if (messageLenght > 0) return 1;
            return 0;
        }
    }
}