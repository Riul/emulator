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
    public class HouseInformations
    {
        public const short Id = 111;
        public int[] doorsOnMap;
        public int houseId;

        public bool isOnSale;
        public bool isSaleLocked;
        public short modelId;
        public string ownerName;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public HouseInformations()
        {
        }

        public HouseInformations(bool isOnSale, bool isSaleLocked, int houseId, int[] doorsOnMap, string ownerName, short modelId)
        {
            this.isOnSale = isOnSale;
            this.isSaleLocked = isSaleLocked;
            this.houseId = houseId;
            this.doorsOnMap = doorsOnMap;
            this.ownerName = ownerName;
            this.modelId = modelId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isOnSale);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isSaleLocked);
            writer.WriteByte(flag1);
            writer.WriteInt(houseId);
            writer.WriteUShort((ushort) doorsOnMap.Length);
            foreach (var entry in doorsOnMap)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUTF(ownerName);
            writer.WriteShort(modelId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            isOnSale = BooleanByteWrapper.GetFlag(flag1, 0);
            isSaleLocked = BooleanByteWrapper.GetFlag(flag1, 1);
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            var limit = reader.ReadUShort();
            doorsOnMap = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                doorsOnMap[i] = reader.ReadInt();
            }
            ownerName = reader.ReadUTF();
            modelId = reader.ReadShort();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
        }
    }
}