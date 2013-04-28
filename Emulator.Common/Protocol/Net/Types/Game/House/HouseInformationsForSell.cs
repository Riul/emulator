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
    public class HouseInformationsForSell
    {
        public const short ID = 221;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int ModelId { get; set; }
        public string OwnerName { get; set; }
        public bool OwnerConnected { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public short SubAreaId { get; set; }
        public sbyte NbRoom { get; set; }
        public sbyte NbChest { get; set; }
        public int[] SkillListIds { get; set; }
        public bool IsLocked { get; set; }
        public int Price { get; set; }


        public HouseInformationsForSell()
        {
        }

        public HouseInformationsForSell(int modelId, string ownerName, bool ownerConnected, short worldX, short worldY, short subAreaId, sbyte nbRoom, sbyte nbChest, int[] skillListIds, bool isLocked, int price)
        {
            ModelId = modelId;
            OwnerName = ownerName;
            OwnerConnected = ownerConnected;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            NbRoom = nbRoom;
            NbChest = nbChest;
            SkillListIds = skillListIds;
            IsLocked = isLocked;
            Price = price;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ModelId);
            writer.WriteUTF(OwnerName);
            writer.WriteBoolean(OwnerConnected);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteShort(SubAreaId);
            writer.WriteSByte(NbRoom);
            writer.WriteSByte(NbChest);
            writer.WriteUShort((ushort) SkillListIds.Length);
            foreach (var entry in SkillListIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteBoolean(IsLocked);
            writer.WriteInt(Price);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ModelId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            OwnerConnected = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadShort();
            NbRoom = reader.ReadSByte();
            NbChest = reader.ReadSByte();
            var limit = reader.ReadUShort();
            SkillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                SkillListIds[i] = reader.ReadInt();
            }
            IsLocked = reader.ReadBoolean();
            Price = reader.ReadInt();
        }
    }
}