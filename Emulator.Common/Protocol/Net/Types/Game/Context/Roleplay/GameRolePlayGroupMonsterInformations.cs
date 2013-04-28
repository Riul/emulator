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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
    {
        public const short ID = 160;

        public override short TypeId
        {
            get { return ID; }
        }

        public GroupMonsterStaticInformations StaticInfos { get; set; }
        public short AgeBonus { get; set; }
        public sbyte LootShare { get; set; }
        public sbyte AlignmentSide { get; set; }
        public bool KeyRingBonus { get; set; }


        public GameRolePlayGroupMonsterInformations()
        {
        }

        public GameRolePlayGroupMonsterInformations(int contextualId, EntityLook look, EntityDispositionInformations disposition, GroupMonsterStaticInformations staticInfos, short ageBonus, sbyte lootShare, sbyte alignmentSide, bool keyRingBonus)
                : base(contextualId, look, disposition)
        {
            StaticInfos = staticInfos;
            AgeBonus = ageBonus;
            LootShare = lootShare;
            AlignmentSide = alignmentSide;
            KeyRingBonus = keyRingBonus;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StaticInfos.TypeId);
            StaticInfos.Serialize(writer);
            writer.WriteShort(AgeBonus);
            writer.WriteSByte(LootShare);
            writer.WriteSByte(AlignmentSide);
            writer.WriteBoolean(KeyRingBonus);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            StaticInfos = Types.ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
            StaticInfos.Deserialize(reader);
            AgeBonus = reader.ReadShort();
            LootShare = reader.ReadSByte();
            AlignmentSide = reader.ReadSByte();
            KeyRingBonus = reader.ReadBoolean();
        }
    }
}