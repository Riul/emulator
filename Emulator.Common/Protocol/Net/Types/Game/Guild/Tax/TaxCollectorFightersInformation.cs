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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorFightersInformation
    {
        public const short Id = 169;

        public CharacterMinimalPlusLookInformations[] allyCharactersInformations;
        public int collectorId;
        public CharacterMinimalPlusLookInformations[] enemyCharactersInformations;


        public TaxCollectorFightersInformation()
        {
        }

        public TaxCollectorFightersInformation(int collectorId, CharacterMinimalPlusLookInformations[] allyCharactersInformations, CharacterMinimalPlusLookInformations[] enemyCharactersInformations)
        {
            this.collectorId = collectorId;
            this.allyCharactersInformations = allyCharactersInformations;
            this.enemyCharactersInformations = enemyCharactersInformations;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(collectorId);
            writer.WriteUShort((ushort) allyCharactersInformations.Length);
            foreach (var entry in allyCharactersInformations)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) enemyCharactersInformations.Length);
            foreach (var entry in enemyCharactersInformations)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            collectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            allyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                allyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                allyCharactersInformations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            enemyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                enemyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                enemyCharactersInformations[i].Deserialize(reader);
            }
        }
    }
}