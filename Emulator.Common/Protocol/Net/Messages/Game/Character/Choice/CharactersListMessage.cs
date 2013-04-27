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
using Emulator.Common.Protocol.Net.Types.Game.Character.Choice;

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Choice
{
    public class CharactersListMessage : NetworkMessage
    {
        public const uint Id = 151;

        public CharacterBaseInformations[] characters;
        public bool hasStartupActions;


        public CharactersListMessage()
        {
        }

        public CharactersListMessage(bool hasStartupActions, CharacterBaseInformations[] characters)
        {
            this.hasStartupActions = hasStartupActions;
            this.characters = characters;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(hasStartupActions);
            writer.WriteUShort((ushort) characters.Length);
            foreach (var entry in characters)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            hasStartupActions = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            characters = new CharacterBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                characters[i] = Types.ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
                characters[i].Deserialize(reader);
            }
        }
    }
}