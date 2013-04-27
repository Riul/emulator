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
    public class GameActionMark
    {
        public const short Id = 351;
        public GameActionMarkedCell[] cells;

        public int markAuthorId;
        public short markId;
        public int markSpellId;
        public sbyte markType;


        public GameActionMark()
        {
        }

        public GameActionMark(int markAuthorId, int markSpellId, short markId, sbyte markType, GameActionMarkedCell[] cells)
        {
            this.markAuthorId = markAuthorId;
            this.markSpellId = markSpellId;
            this.markId = markId;
            this.markType = markType;
            this.cells = cells;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(markAuthorId);
            writer.WriteInt(markSpellId);
            writer.WriteShort(markId);
            writer.WriteSByte(markType);
            writer.WriteUShort((ushort) cells.Length);
            foreach (var entry in cells)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            markAuthorId = reader.ReadInt();
            markSpellId = reader.ReadInt();
            if (markSpellId < 0)
                throw new Exception("Forbidden value on markSpellId = " + markSpellId + ", it doesn't respect the following condition : markSpellId < 0");
            markId = reader.ReadShort();
            markType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            cells = new GameActionMarkedCell[limit];
            for (int i = 0; i < limit; i++)
            {
                cells[i] = new GameActionMarkedCell();
                cells[i].Deserialize(reader);
            }
        }
    }
}