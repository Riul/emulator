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
    public class HouseInformations
    {
        public const short ID = 111;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool IsOnSale { get; set; }
        public bool IsSaleLocked { get; set; }
        public int HouseId { get; set; }
        public int[] DoorsOnMap { get; set; }
        public string OwnerName { get; set; }
        public short ModelId { get; set; }


        public HouseInformations()
        {
        }

        public HouseInformations(bool isOnSale, bool isSaleLocked, int houseId, int[] doorsOnMap, string ownerName, short modelId)
        {
            IsOnSale = isOnSale;
            IsSaleLocked = isSaleLocked;
            HouseId = houseId;
            DoorsOnMap = doorsOnMap;
            OwnerName = ownerName;
            ModelId = modelId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, IsOnSale);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, IsSaleLocked);
            writer.WriteByte(flag1);
            writer.WriteInt(HouseId);
            writer.WriteUShort((ushort) DoorsOnMap.Length);
            foreach (var entry in DoorsOnMap)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUTF(OwnerName);
            writer.WriteShort(ModelId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            IsOnSale = BooleanByteWrapper.GetFlag(flag1, 0);
            IsSaleLocked = BooleanByteWrapper.GetFlag(flag1, 1);
            HouseId = reader.ReadInt();
            var limit = reader.ReadUShort();
            DoorsOnMap = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                DoorsOnMap[i] = reader.ReadInt();
            }
            OwnerName = reader.ReadUTF();
            ModelId = reader.ReadShort();
        }
    }
}