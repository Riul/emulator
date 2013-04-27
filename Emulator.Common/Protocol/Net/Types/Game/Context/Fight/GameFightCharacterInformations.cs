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
using Emulator.Common.Protocol.Net.Types.Game.Character.Alignment;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public const short Id = 46;

        public ActorAlignmentInformations alignmentInfos;
        public sbyte breed;
        public short level;


        public GameFightCharacterInformations()
        {
        }

        public GameFightCharacterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, sbyte teamId, bool alive, GameFightMinimalStats stats, string name, short level, ActorAlignmentInformations alignmentInfos, sbyte breed)
            : base(contextualId, look, disposition, teamId, alive, stats, name)
        {
            this.level = level;
            this.alignmentInfos = alignmentInfos;
            this.breed = breed;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(level);
            alignmentInfos.Serialize(writer);
            writer.WriteSByte(breed);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadShort();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            alignmentInfos = new ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
            breed = reader.ReadSByte();
        }
    }
}