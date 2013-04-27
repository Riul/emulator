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
    public class AlternativeMonstersInGroupLightInformations
    {
        public const short Id = 394;

        public MonsterInGroupLightInformations[] monsters;
        public int playerCount;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public AlternativeMonstersInGroupLightInformations()
        {
        }

        public AlternativeMonstersInGroupLightInformations(int playerCount, MonsterInGroupLightInformations[] monsters)
        {
            this.playerCount = playerCount;
            this.monsters = monsters;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(playerCount);
            writer.WriteUShort((ushort) monsters.Length);
            foreach (var entry in monsters)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            playerCount = reader.ReadInt();
            var limit = reader.ReadUShort();
            monsters = new MonsterInGroupLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                monsters[i] = new MonsterInGroupLightInformations();
                monsters[i].Deserialize(reader);
            }
        }
    }
}