#region License
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
//                Version 2, December 2004
//  
// Copyright (C) 2013 Phito <phito41@gmail.com>
//  
// Everyone is permitted to copy and distribute verbatim or modified
// copies of this license document, and changing it is allowed as long
// as the name is changed.
//  
//         DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
// TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
//  
// 0. You just DO WHAT THE FUCK YOU WANT TO.
// 
// Created on 26/04/2013 at 16:46
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

        public override short TypeId
        {
            get { return Id; }
        }


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