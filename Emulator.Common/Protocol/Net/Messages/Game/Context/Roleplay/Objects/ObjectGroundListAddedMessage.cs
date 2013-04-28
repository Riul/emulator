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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Objects
{
    public class ObjectGroundListAddedMessage : NetworkMessage
    {
        public const uint ID = 5925;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] Cells { get; set; }
        public int[] ReferenceIds { get; set; }


        public ObjectGroundListAddedMessage()
        {
        }

        public ObjectGroundListAddedMessage(short[] cells, int[] referenceIds)
        {
            Cells = cells;
            ReferenceIds = referenceIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Cells.Length);
            foreach (var entry in Cells)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) ReferenceIds.Length);
            foreach (var entry in ReferenceIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Cells[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            ReferenceIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ReferenceIds[i] = reader.ReadInt();
            }
        }
    }
}