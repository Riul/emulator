#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:46
// */
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