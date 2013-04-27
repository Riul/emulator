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
//     Created on 26/04/2013 at 16:45
// */
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