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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Debug
{
    public class DebugHighlightCellsMessage : NetworkMessage
    {
        public const uint ID = 2001;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Color { get; set; }
        public short[] Cells { get; set; }


        public DebugHighlightCellsMessage()
        {
        }

        public DebugHighlightCellsMessage(int color, short[] cells)
        {
            Color = color;
            Cells = cells;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Color);
            writer.WriteUShort((ushort) Cells.Length);
            foreach (var entry in Cells)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Color = reader.ReadInt();
            var limit = reader.ReadUShort();
            Cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Cells[i] = reader.ReadShort();
            }
        }
    }
}