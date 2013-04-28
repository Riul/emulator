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

namespace Emulator.Common.Protocol.Net.Types.Game.Actions.Fight
{
    public class GameActionMarkedCell
    {
        public const short ID = 85;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short CellId { get; set; }
        public sbyte ZoneSize { get; set; }
        public int CellColor { get; set; }
        public sbyte CellsType { get; set; }


        public GameActionMarkedCell()
        {
        }

        public GameActionMarkedCell(short cellId, sbyte zoneSize, int cellColor, sbyte cellsType)
        {
            CellId = cellId;
            ZoneSize = zoneSize;
            CellColor = cellColor;
            CellsType = cellsType;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(CellId);
            writer.WriteSByte(ZoneSize);
            writer.WriteInt(CellColor);
            writer.WriteSByte(CellsType);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            CellId = reader.ReadShort();
            ZoneSize = reader.ReadSByte();
            CellColor = reader.ReadInt();
            CellsType = reader.ReadSByte();
        }
    }
}