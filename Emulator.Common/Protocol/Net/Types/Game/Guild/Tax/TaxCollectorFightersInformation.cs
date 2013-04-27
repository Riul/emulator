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
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorFightersInformation
    {
        public const short Id = 169;

        public CharacterMinimalPlusLookInformations[] allyCharactersInformations;
        public int collectorId;
        public CharacterMinimalPlusLookInformations[] enemyCharactersInformations;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public TaxCollectorFightersInformation()
        {
        }

        public TaxCollectorFightersInformation(int collectorId, CharacterMinimalPlusLookInformations[] allyCharactersInformations, CharacterMinimalPlusLookInformations[] enemyCharactersInformations)
        {
            this.collectorId = collectorId;
            this.allyCharactersInformations = allyCharactersInformations;
            this.enemyCharactersInformations = enemyCharactersInformations;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(collectorId);
            writer.WriteUShort((ushort) allyCharactersInformations.Length);
            foreach (var entry in allyCharactersInformations)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) enemyCharactersInformations.Length);
            foreach (var entry in enemyCharactersInformations)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            collectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            allyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                allyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                allyCharactersInformations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            enemyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                enemyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                enemyCharactersInformations[i].Deserialize(reader);
            }
        }
    }
}