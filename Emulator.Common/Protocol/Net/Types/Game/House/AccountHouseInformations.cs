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
    public class AccountHouseInformations
    {
        public const short ID = 390;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int HouseId { get; set; }
        public short ModelId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }


        public AccountHouseInformations()
        {
        }

        public AccountHouseInformations(int houseId, short modelId, short worldX, short worldY, int mapId, short subAreaId)
        {
            HouseId = houseId;
            ModelId = modelId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(HouseId);
            writer.WriteShort(ModelId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            HouseId = reader.ReadInt();
            ModelId = reader.ReadShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
        }
    }
}