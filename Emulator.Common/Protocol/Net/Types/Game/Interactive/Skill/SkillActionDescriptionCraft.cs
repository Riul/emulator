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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public const short Id = 100;

        public sbyte maxSlots;
        public sbyte probability;


        public SkillActionDescriptionCraft()
        {
        }

        public SkillActionDescriptionCraft(short skillId, sbyte maxSlots, sbyte probability)
            : base(skillId)
        {
            this.maxSlots = maxSlots;
            this.probability = probability;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(maxSlots);
            writer.WriteSByte(probability);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            maxSlots = reader.ReadSByte();
            if (maxSlots < 0)
                throw new Exception("Forbidden value on maxSlots = " + maxSlots + ", it doesn't respect the following condition : maxSlots < 0");
            probability = reader.ReadSByte();
            if (probability < 0)
                throw new Exception("Forbidden value on probability = " + probability + ", it doesn't respect the following condition : probability < 0");
        }
    }
}