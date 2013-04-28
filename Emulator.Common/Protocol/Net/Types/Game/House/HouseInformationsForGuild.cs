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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.House
{
    public class HouseInformationsForGuild
    {
        public const short ID = 170;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int HouseId { get; set; }
        public int ModelId { get; set; }
        public string OwnerName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public int[] SkillListIds { get; set; }
        public uint GuildshareParams { get; set; }


        public HouseInformationsForGuild()
        {
        }

        public HouseInformationsForGuild(int houseId, int modelId, string ownerName, short worldX, short worldY, int mapId, short subAreaId, int[] skillListIds, uint guildshareParams)
        {
            HouseId = houseId;
            ModelId = modelId;
            OwnerName = ownerName;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            SkillListIds = skillListIds;
            GuildshareParams = guildshareParams;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(HouseId);
            writer.WriteInt(ModelId);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteUShort((ushort) SkillListIds.Length);
            foreach (var entry in SkillListIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUInt(GuildshareParams);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            HouseId = reader.ReadInt();
            ModelId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            var limit = reader.ReadUShort();
            SkillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                SkillListIds[i] = reader.ReadInt();
            }
            GuildshareParams = reader.ReadUInt();
        }
    }
}