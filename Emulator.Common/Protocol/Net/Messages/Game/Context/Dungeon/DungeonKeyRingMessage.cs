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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Dungeon
{
    public class DungeonKeyRingMessage : NetworkMessage
    {
        public const uint Id = 6299;

        public short[] availables;
        public short[] unavailables;


        public DungeonKeyRingMessage()
        {
        }

        public DungeonKeyRingMessage(short[] availables, short[] unavailables)
        {
            this.availables = availables;
            this.unavailables = unavailables;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) availables.Length);
            foreach (var entry in availables)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) unavailables.Length);
            foreach (var entry in unavailables)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            availables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                availables[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            unavailables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                unavailables[i] = reader.ReadShort();
            }
        }
    }
}