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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.House
{
    public class HouseInformationsForSell
    {
        public const short Id = 221;
        public bool isLocked;

        public int modelId;
        public sbyte nbChest;
        public sbyte nbRoom;
        public bool ownerConnected;
        public string ownerName;
        public int price;
        public int[] skillListIds;
        public short subAreaId;
        public short worldX;
        public short worldY;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public HouseInformationsForSell()
        {
        }

        public HouseInformationsForSell(int modelId, string ownerName, bool ownerConnected, short worldX, short worldY, short subAreaId, sbyte nbRoom, sbyte nbChest, int[] skillListIds, bool isLocked, int price)
        {
            this.modelId = modelId;
            this.ownerName = ownerName;
            this.ownerConnected = ownerConnected;
            this.worldX = worldX;
            this.worldY = worldY;
            this.subAreaId = subAreaId;
            this.nbRoom = nbRoom;
            this.nbChest = nbChest;
            this.skillListIds = skillListIds;
            this.isLocked = isLocked;
            this.price = price;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(modelId);
            writer.WriteUTF(ownerName);
            writer.WriteBoolean(ownerConnected);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteShort(subAreaId);
            writer.WriteSByte(nbRoom);
            writer.WriteSByte(nbChest);
            writer.WriteUShort((ushort) skillListIds.Length);
            foreach (var entry in skillListIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteBoolean(isLocked);
            writer.WriteInt(price);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            modelId = reader.ReadInt();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
            ownerName = reader.ReadUTF();
            ownerConnected = reader.ReadBoolean();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            nbRoom = reader.ReadSByte();
            nbChest = reader.ReadSByte();
            var limit = reader.ReadUShort();
            skillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                skillListIds[i] = reader.ReadInt();
            }
            isLocked = reader.ReadBoolean();
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
        }
    }
}