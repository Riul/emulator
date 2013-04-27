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

using System.Collections.Generic;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Creation
{
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const uint Id = 160;

        public int breed = 0;
        public List<int> colors;
        public int cosmeticId = 0;
        public string name = "";
        public bool sex = false;

        public CharacterCreationRequestMessage()
        {
            colors = new List<int>();
        }

        public CharacterCreationRequestMessage(string name, int breed, bool sex, List<int> colors, int cosmeticId)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
            this.cosmeticId = cosmeticId;
        }

        public override uint MessageId
        {
            get { return 160; }
        }

        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteByte((byte)breed);
            writer.WriteBoolean(sex);
            foreach (var color in colors)
            {
                writer.WriteInt(color);
            }
            writer.WriteInt(cosmeticId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            name = reader.ReadUTF();
            breed = reader.ReadByte();
            sex = reader.ReadBoolean();
            colors = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                colors.Add(reader.ReadInt());
            }
            cosmeticId = reader.ReadInt();
        }
    }
}
