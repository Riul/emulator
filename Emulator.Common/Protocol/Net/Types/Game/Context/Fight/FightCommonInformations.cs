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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightCommonInformations
    {
        public const short Id = 43;

        public int fightId;
        public FightTeamInformations[] fightTeams;
        public FightOptionsInformations[] fightTeamsOptions;
        public short[] fightTeamsPositions;
        public sbyte fightType;


        public FightCommonInformations()
        {
        }

        public FightCommonInformations(int fightId, sbyte fightType, FightTeamInformations[] fightTeams, short[] fightTeamsPositions, FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightTeams = fightTeams;
            this.fightTeamsPositions = fightTeamsPositions;
            this.fightTeamsOptions = fightTeamsOptions;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteSByte(fightType);
            writer.WriteUShort((ushort) fightTeams.Length);
            foreach (var entry in fightTeams)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) fightTeamsPositions.Length);
            foreach (var entry in fightTeamsPositions)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) fightTeamsOptions.Length);
            foreach (var entry in fightTeamsOptions)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadInt();
            fightType = reader.ReadSByte();
            if (fightType < 0)
                throw new Exception("Forbidden value on fightType = " + fightType + ", it doesn't respect the following condition : fightType < 0");
            var limit = reader.ReadUShort();
            fightTeams = new FightTeamInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeams[i] = new FightTeamInformations();
                fightTeams[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fightTeamsPositions = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeamsPositions[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            fightTeamsOptions = new FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                fightTeamsOptions[i] = new FightOptionsInformations();
                fightTeamsOptions[i].Deserialize(reader);
            }
        }
    }
}