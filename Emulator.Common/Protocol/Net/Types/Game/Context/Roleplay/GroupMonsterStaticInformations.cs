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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class GroupMonsterStaticInformations
    {
        public const short ID = 140;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public MonsterInGroupLightInformations MainCreatureLightInfos { get; set; }
        public MonsterInGroupInformations[] Underlings { get; set; }


        public GroupMonsterStaticInformations()
        {
        }

        public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos, MonsterInGroupInformations[] underlings)
        {
            MainCreatureLightInfos = mainCreatureLightInfos;
            Underlings = underlings;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            MainCreatureLightInfos.Serialize(writer);
            writer.WriteUShort((ushort) Underlings.Length);
            foreach (var entry in Underlings)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            MainCreatureLightInfos = new MonsterInGroupLightInformations();
            MainCreatureLightInfos.Deserialize(reader);
            var limit = reader.ReadUShort();
            Underlings = new MonsterInGroupInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Underlings[i] = new MonsterInGroupInformations();
                Underlings[i].Deserialize(reader);
            }
        }
    }
}