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
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefendersStateMessage : NetworkMessage
    {
        public const uint Id = 5899;

        public double fightId;
        public CharacterMinimalPlusLookAndGradeInformations[] mainFighters;
        public CharacterMinimalPlusLookAndGradeInformations[] reserveFighters;


        public PrismFightDefendersStateMessage()
        {
        }

        public PrismFightDefendersStateMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations[] mainFighters, CharacterMinimalPlusLookAndGradeInformations[] reserveFighters)
        {
            this.fightId = fightId;
            this.mainFighters = mainFighters;
            this.reserveFighters = reserveFighters;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort) mainFighters.Length);
            foreach (var entry in mainFighters)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) reserveFighters.Length);
            foreach (var entry in reserveFighters)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            mainFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                mainFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                mainFighters[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            reserveFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                reserveFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                reserveFighters[i].Deserialize(reader);
            }
        }
    }
}