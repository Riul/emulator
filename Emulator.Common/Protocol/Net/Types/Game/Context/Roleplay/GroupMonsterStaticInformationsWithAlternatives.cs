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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public const short Id = 396;

        public AlternativeMonstersInGroupLightInformations[] alternatives;

        public override short TypeId
        {
            get { return Id; }
        }


        public GroupMonsterStaticInformationsWithAlternatives()
        {
        }

        public GroupMonsterStaticInformationsWithAlternatives(MonsterInGroupLightInformations mainCreatureLightInfos, MonsterInGroupInformations[] underlings, AlternativeMonstersInGroupLightInformations[] alternatives)
            : base(mainCreatureLightInfos, underlings)
        {
            this.alternatives = alternatives;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) alternatives.Length);
            foreach (var entry in alternatives)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            alternatives = new AlternativeMonstersInGroupLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                alternatives[i] = new AlternativeMonstersInGroupLightInformations();
                alternatives[i].Deserialize(reader);
            }
        }
    }
}