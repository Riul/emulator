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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Debug
{
    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const uint Id = 2001;

        public short[] cells;
        public int color;

        public override uint MessageId
        {
            get { return Id; }
        }


        public DebugHighlightCellsMessage()
        {
        }

        public DebugHighlightCellsMessage(int color, short[] cells)
        {
            this.color = color;
            this.cells = cells;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(color);
            writer.WriteUShort((ushort) cells.Length);
            foreach (var entry in cells)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            color = reader.ReadInt();
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                cells[i] = reader.ReadShort();
            }
        }
    }
}