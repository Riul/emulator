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
using Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic;
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Spells
{
    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const uint Id = 6214;

        public int slaveId;
        public SpellItem[] slaveSpells;
        public CharacterCharacteristicsInformations slaveStats;
        public int summonerId;


        public SlaveSwitchContextMessage()
        {
        }

        public SlaveSwitchContextMessage(int summonerId, int slaveId, SpellItem[] slaveSpells, CharacterCharacteristicsInformations slaveStats)
        {
            this.summonerId = summonerId;
            this.slaveId = slaveId;
            this.slaveSpells = slaveSpells;
            this.slaveStats = slaveStats;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(summonerId);
            writer.WriteInt(slaveId);
            writer.WriteUShort((ushort) slaveSpells.Length);
            foreach (var entry in slaveSpells)
            {
                entry.Serialize(writer);
            }
            slaveStats.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            summonerId = reader.ReadInt();
            slaveId = reader.ReadInt();
            var limit = reader.ReadUShort();
            slaveSpells = new SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                slaveSpells[i] = new SpellItem();
                slaveSpells[i].Deserialize(reader);
            }
            slaveStats = new CharacterCharacteristicsInformations();
            slaveStats.Deserialize(reader);
        }
    }
}