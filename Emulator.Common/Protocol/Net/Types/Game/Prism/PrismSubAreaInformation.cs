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

namespace Emulator.Common.Protocol.Net.Types.Game.Prism
{
    public class PrismSubAreaInformation
    {
        public const short ID = 142;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public sbyte Alignment { get; set; }
        public bool IsInFight { get; set; }
        public bool IsFightable { get; set; }


        public PrismSubAreaInformation()
        {
        }

        public PrismSubAreaInformation(short worldX, short worldY, int mapId, short subAreaId, sbyte alignment, bool isInFight, bool isFightable)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Alignment = alignment;
            IsInFight = isInFight;
            IsFightable = isFightable;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteSByte(Alignment);
            writer.WriteBoolean(IsInFight);
            writer.WriteBoolean(IsFightable);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            Alignment = reader.ReadSByte();
            IsInFight = reader.ReadBoolean();
            IsFightable = reader.ReadBoolean();
        }
    }
}