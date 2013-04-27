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

namespace Emulator.Common.Protocol.Net.Types.Game.Prism
{
    public class VillageConquestPrismInformation
    {
        public const short Id = 379;
        public sbyte areaAlignment;
        public short areaId;

        public bool isEntered;
        public bool isInRoom;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public VillageConquestPrismInformation()
        {
        }

        public VillageConquestPrismInformation(bool isEntered, bool isInRoom, short areaId, sbyte areaAlignment)
        {
            this.isEntered = isEntered;
            this.isInRoom = isInRoom;
            this.areaId = areaId;
            this.areaAlignment = areaAlignment;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isEntered);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isInRoom);
            writer.WriteByte(flag1);
            writer.WriteShort(areaId);
            writer.WriteSByte(areaAlignment);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            isEntered = BooleanByteWrapper.GetFlag(flag1, 0);
            isInRoom = BooleanByteWrapper.GetFlag(flag1, 1);
            areaId = reader.ReadShort();
            if (areaId < 0)
                throw new Exception("Forbidden value on areaId = " + areaId + ", it doesn't respect the following condition : areaId < 0");
            areaAlignment = reader.ReadSByte();
            if (areaAlignment < 0)
                throw new Exception("Forbidden value on areaAlignment = " + areaAlignment + ", it doesn't respect the following condition : areaAlignment < 0");
        }
    }
}