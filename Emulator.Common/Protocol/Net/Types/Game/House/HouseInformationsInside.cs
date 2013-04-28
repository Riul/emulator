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
    public class HouseInformationsInside
    {
        public const short ID = 218;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int HouseId { get; set; }
        public short ModelId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public uint Price { get; set; }
        public bool IsLocked { get; set; }


        public HouseInformationsInside()
        {
        }

        public HouseInformationsInside(int houseId, short modelId, int ownerId, string ownerName, short worldX, short worldY, uint price, bool isLocked)
        {
            HouseId = houseId;
            ModelId = modelId;
            OwnerId = ownerId;
            OwnerName = ownerName;
            WorldX = worldX;
            WorldY = worldY;
            Price = price;
            IsLocked = isLocked;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(HouseId);
            writer.WriteShort(ModelId);
            writer.WriteInt(OwnerId);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUInt(Price);
            writer.WriteBoolean(IsLocked);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            HouseId = reader.ReadInt();
            ModelId = reader.ReadShort();
            OwnerId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Price = reader.ReadUInt();
            IsLocked = reader.ReadBoolean();
        }
    }
}