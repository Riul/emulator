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
    public class VillageConquestPrismInformation
    {
        public const short ID = 379;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool IsEntered { get; set; }
        public bool IsInRoom { get; set; }
        public short AreaId { get; set; }
        public sbyte AreaAlignment { get; set; }


        public VillageConquestPrismInformation()
        {
        }

        public VillageConquestPrismInformation(bool isEntered, bool isInRoom, short areaId, sbyte areaAlignment)
        {
            IsEntered = isEntered;
            IsInRoom = isInRoom;
            AreaId = areaId;
            AreaAlignment = areaAlignment;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, IsEntered);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, IsInRoom);
            writer.WriteByte(flag1);
            writer.WriteShort(AreaId);
            writer.WriteSByte(AreaAlignment);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            IsEntered = BooleanByteWrapper.GetFlag(flag1, 0);
            IsInRoom = BooleanByteWrapper.GetFlag(flag1, 1);
            AreaId = reader.ReadShort();
            AreaAlignment = reader.ReadSByte();
        }
    }
}