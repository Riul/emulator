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
//     Created on 26/04/2013 at 16:45
// */
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Tinsel
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const uint Id = 6367;

        public short activeOrnament;
        public short activeTitle;
        public short[] ornaments;
        public short[] titles;


        public TitlesAndOrnamentsListMessage()
        {
        }

        public TitlesAndOrnamentsListMessage(short[] titles, short[] ornaments, short activeTitle, short activeOrnament)
        {
            this.titles = titles;
            this.ornaments = ornaments;
            this.activeTitle = activeTitle;
            this.activeOrnament = activeOrnament;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) titles.Length);
            foreach (var entry in titles)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) ornaments.Length);
            foreach (var entry in ornaments)
            {
                writer.WriteShort(entry);
            }
            writer.WriteShort(activeTitle);
            writer.WriteShort(activeOrnament);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            titles = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                titles[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            ornaments = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                ornaments[i] = reader.ReadShort();
            }
            activeTitle = reader.ReadShort();
            if (activeTitle < 0)
                throw new Exception("Forbidden value on activeTitle = " + activeTitle + ", it doesn't respect the following condition : activeTitle < 0");
            activeOrnament = reader.ReadShort();
            if (activeOrnament < 0)
                throw new Exception("Forbidden value on activeOrnament = " + activeOrnament + ", it doesn't respect the following condition : activeOrnament < 0");
        }
    }
}