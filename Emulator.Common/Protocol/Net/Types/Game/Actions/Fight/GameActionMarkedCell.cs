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

namespace Emulator.Common.Protocol.Net.Types.Game.Actions.Fight
{
    public class GameActionMarkedCell
    {
        public const short Id = 85;

        public int cellColor;
        public short cellId;
        public sbyte cellsType;
        public sbyte zoneSize;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public GameActionMarkedCell()
        {
        }

        public GameActionMarkedCell(short cellId, sbyte zoneSize, int cellColor, sbyte cellsType)
        {
            this.cellId = cellId;
            this.zoneSize = zoneSize;
            this.cellColor = cellColor;
            this.cellsType = cellsType;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(cellId);
            writer.WriteSByte(zoneSize);
            writer.WriteInt(cellColor);
            writer.WriteSByte(cellsType);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
            zoneSize = reader.ReadSByte();
            cellColor = reader.ReadInt();
            cellsType = reader.ReadSByte();
        }
    }
}