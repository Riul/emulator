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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Pvp
{
    public class AlignmentSubAreaUpdateExtendedMessage : AlignmentSubAreaUpdateMessage
    {
        public const uint Id = 6319;
        public sbyte eventType;
        public int mapId;

        public short worldX;
        public short worldY;


        public AlignmentSubAreaUpdateExtendedMessage()
        {
        }

        public AlignmentSubAreaUpdateExtendedMessage(short subAreaId, sbyte side, bool quiet, short worldX, short worldY, int mapId, sbyte eventType)
            : base(subAreaId, side, quiet)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.eventType = eventType;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteSByte(eventType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            eventType = reader.ReadSByte();
        }
    }
}