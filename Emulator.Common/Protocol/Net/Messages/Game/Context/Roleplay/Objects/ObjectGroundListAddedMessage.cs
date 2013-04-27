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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Objects
{
    public class ObjectGroundListAddedMessage : NetworkMessage
    {
        public const uint Id = 5925;

        public short[] cells;
        public int[] referenceIds;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ObjectGroundListAddedMessage()
        {
        }

        public ObjectGroundListAddedMessage(short[] cells, int[] referenceIds)
        {
            this.cells = cells;
            this.referenceIds = referenceIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) cells.Length);
            foreach (var entry in cells)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) referenceIds.Length);
            foreach (var entry in referenceIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                cells[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            referenceIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                referenceIds[i] = reader.ReadInt();
            }
        }
    }
}