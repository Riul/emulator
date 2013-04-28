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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorInformations
    {
        public const short ID = 167;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int UniqueId { get; set; }
        public short FirtNameId { get; set; }
        public short LastNameId { get; set; }
        public AdditionalTaxCollectorInformations AdditionalInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public short SubAreaId { get; set; }
        public sbyte State { get; set; }
        public EntityLook Look { get; set; }
        public int Kamas { get; set; }
        public double Experience { get; set; }
        public int Pods { get; set; }
        public int ItemsValue { get; set; }


        public TaxCollectorInformations()
        {
        }

        public TaxCollectorInformations(int uniqueId, short firtNameId, short lastNameId, AdditionalTaxCollectorInformations additionalInfos, short worldX, short worldY, short subAreaId, sbyte state, EntityLook look, int kamas, double experience, int pods, int itemsValue)
        {
            UniqueId = uniqueId;
            FirtNameId = firtNameId;
            LastNameId = lastNameId;
            AdditionalInfos = additionalInfos;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            State = state;
            Look = look;
            Kamas = kamas;
            Experience = experience;
            Pods = pods;
            ItemsValue = itemsValue;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(UniqueId);
            writer.WriteShort(FirtNameId);
            writer.WriteShort(LastNameId);
            AdditionalInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteShort(SubAreaId);
            writer.WriteSByte(State);
            Look.Serialize(writer);
            writer.WriteInt(Kamas);
            writer.WriteDouble(Experience);
            writer.WriteInt(Pods);
            writer.WriteInt(ItemsValue);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            UniqueId = reader.ReadInt();
            FirtNameId = reader.ReadShort();
            LastNameId = reader.ReadShort();
            AdditionalInfos = new AdditionalTaxCollectorInformations();
            AdditionalInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadShort();
            State = reader.ReadSByte();
            Look = new EntityLook();
            Look.Deserialize(reader);
            Kamas = reader.ReadInt();
            Experience = reader.ReadDouble();
            Pods = reader.ReadInt();
            ItemsValue = reader.ReadInt();
        }
    }
}