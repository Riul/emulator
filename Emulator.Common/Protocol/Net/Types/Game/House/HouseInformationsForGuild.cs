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
//     Created on 26/04/2013 at 16:46
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.House
{
    public class HouseInformationsForGuild
    {
        public const short Id = 170;
        public uint guildshareParams;

        public int houseId;
        public int mapId;
        public int modelId;
        public string ownerName;
        public int[] skillListIds;
        public short subAreaId;
        public short worldX;
        public short worldY;


        public HouseInformationsForGuild()
        {
        }

        public HouseInformationsForGuild(int houseId, int modelId, string ownerName, short worldX, short worldY, int mapId, short subAreaId, int[] skillListIds, uint guildshareParams)
        {
            this.houseId = houseId;
            this.modelId = modelId;
            this.ownerName = ownerName;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.skillListIds = skillListIds;
            this.guildshareParams = guildshareParams;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(houseId);
            writer.WriteInt(modelId);
            writer.WriteUTF(ownerName);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(subAreaId);
            writer.WriteUShort((ushort) skillListIds.Length);
            foreach (var entry in skillListIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUInt(guildshareParams);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            modelId = reader.ReadInt();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
            ownerName = reader.ReadUTF();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            var limit = reader.ReadUShort();
            skillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                skillListIds[i] = reader.ReadInt();
            }
            guildshareParams = reader.ReadUInt();
            if (guildshareParams < 0 || guildshareParams > 4294967295)
                throw new Exception("Forbidden value on guildshareParams = " + guildshareParams + ", it doesn't respect the following condition : guildshareParams < 0 || guildshareParams > 4294967295");
        }
    }
}