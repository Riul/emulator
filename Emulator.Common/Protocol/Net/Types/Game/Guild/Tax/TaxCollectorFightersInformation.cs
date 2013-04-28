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
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild.Tax
{
    public class TaxCollectorFightersInformation
    {
        public const short ID = 169;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int CollectorId { get; set; }
        public CharacterMinimalPlusLookInformations[] AllyCharactersInformations { get; set; }
        public CharacterMinimalPlusLookInformations[] EnemyCharactersInformations { get; set; }


        public TaxCollectorFightersInformation()
        {
        }

        public TaxCollectorFightersInformation(int collectorId, CharacterMinimalPlusLookInformations[] allyCharactersInformations, CharacterMinimalPlusLookInformations[] enemyCharactersInformations)
        {
            CollectorId = collectorId;
            AllyCharactersInformations = allyCharactersInformations;
            EnemyCharactersInformations = enemyCharactersInformations;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(CollectorId);
            writer.WriteUShort((ushort) AllyCharactersInformations.Length);
            foreach (var entry in AllyCharactersInformations)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) EnemyCharactersInformations.Length);
            foreach (var entry in EnemyCharactersInformations)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            CollectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            AllyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                AllyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                AllyCharactersInformations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            EnemyCharactersInformations = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                EnemyCharactersInformations[i] = new CharacterMinimalPlusLookInformations();
                EnemyCharactersInformations[i].Deserialize(reader);
            }
        }
    }
}