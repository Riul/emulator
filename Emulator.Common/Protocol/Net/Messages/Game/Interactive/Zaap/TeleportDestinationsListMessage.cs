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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Zaap
{
    public class TeleportDestinationsListMessage : NetworkMessage
    {
        public const uint Id = 5960;
        public short[] costs;

        public int[] mapIds;
        public short[] subAreaIds;
        public sbyte teleporterType;


        public TeleportDestinationsListMessage()
        {
        }

        public TeleportDestinationsListMessage(sbyte teleporterType, int[] mapIds, short[] subAreaIds, short[] costs)
        {
            this.teleporterType = teleporterType;
            this.mapIds = mapIds;
            this.subAreaIds = subAreaIds;
            this.costs = costs;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(teleporterType);
            writer.WriteUShort((ushort) mapIds.Length);
            foreach (var entry in mapIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) subAreaIds.Length);
            foreach (var entry in subAreaIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) costs.Length);
            foreach (var entry in costs)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            teleporterType = reader.ReadSByte();
            if (teleporterType < 0)
                throw new Exception("Forbidden value on teleporterType = " + teleporterType + ", it doesn't respect the following condition : teleporterType < 0");
            var limit = reader.ReadUShort();
            mapIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                mapIds[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            subAreaIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                subAreaIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            costs = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                costs[i] = reader.ReadShort();
            }
        }
    }
}