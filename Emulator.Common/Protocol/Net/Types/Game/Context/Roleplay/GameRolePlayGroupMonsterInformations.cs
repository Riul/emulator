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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public const short Id = 160;

        public short ageBonus;
        public sbyte alignmentSide;
        public bool keyRingBonus;
        public sbyte lootShare;
        public GroupMonsterStaticInformations staticInfos;


        public GameRolePlayGroupMonsterInformations()
        {
        }

        public GameRolePlayGroupMonsterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, GroupMonsterStaticInformations staticInfos, short ageBonus, sbyte lootShare, sbyte alignmentSide, bool keyRingBonus)
            : base(contextualId, look, disposition)
        {
            this.staticInfos = staticInfos;
            this.ageBonus = ageBonus;
            this.lootShare = lootShare;
            this.alignmentSide = alignmentSide;
            this.keyRingBonus = keyRingBonus;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(staticInfos.TypeId);
            staticInfos.Serialize(writer);
            writer.WriteShort(ageBonus);
            writer.WriteSByte(lootShare);
            writer.WriteSByte(alignmentSide);
            writer.WriteBoolean(keyRingBonus);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            staticInfos = Types.ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
            staticInfos.Deserialize(reader);
            ageBonus = reader.ReadShort();
            if (ageBonus < -1 || ageBonus > 1000)
                throw new Exception("Forbidden value on ageBonus = " + ageBonus + ", it doesn't respect the following condition : ageBonus < -1 || ageBonus > 1000");
            lootShare = reader.ReadSByte();
            if (lootShare < -1 || lootShare > 8)
                throw new Exception("Forbidden value on lootShare = " + lootShare + ", it doesn't respect the following condition : lootShare < -1 || lootShare > 8");
            alignmentSide = reader.ReadSByte();
            keyRingBonus = reader.ReadBoolean();
        }
    }
}