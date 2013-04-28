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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Guild
{
    public class GuildInfosUpgradeMessage : NetworkMessage
    {
        public const uint ID = 5636;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte MaxTaxCollectorsCount { get; set; }
        public sbyte TaxCollectorsCount { get; set; }
        public short TaxCollectorLifePoints { get; set; }
        public short TaxCollectorDamagesBonuses { get; set; }
        public short TaxCollectorPods { get; set; }
        public short TaxCollectorProspecting { get; set; }
        public short TaxCollectorWisdom { get; set; }
        public short BoostPoints { get; set; }
        public short[] SpellId { get; set; }
        public sbyte[] SpellLevel { get; set; }


        public GuildInfosUpgradeMessage()
        {
        }

        public GuildInfosUpgradeMessage(sbyte maxTaxCollectorsCount, sbyte taxCollectorsCount, short taxCollectorLifePoints, short taxCollectorDamagesBonuses, short taxCollectorPods, short taxCollectorProspecting, short taxCollectorWisdom, short boostPoints, short[] spellId, sbyte[] spellLevel)
        {
            MaxTaxCollectorsCount = maxTaxCollectorsCount;
            TaxCollectorsCount = taxCollectorsCount;
            TaxCollectorLifePoints = taxCollectorLifePoints;
            TaxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
            TaxCollectorPods = taxCollectorPods;
            TaxCollectorProspecting = taxCollectorProspecting;
            TaxCollectorWisdom = taxCollectorWisdom;
            BoostPoints = boostPoints;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(MaxTaxCollectorsCount);
            writer.WriteSByte(TaxCollectorsCount);
            writer.WriteShort(TaxCollectorLifePoints);
            writer.WriteShort(TaxCollectorDamagesBonuses);
            writer.WriteShort(TaxCollectorPods);
            writer.WriteShort(TaxCollectorProspecting);
            writer.WriteShort(TaxCollectorWisdom);
            writer.WriteShort(BoostPoints);
            writer.WriteUShort((ushort) SpellId.Length);
            foreach (var entry in SpellId)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) SpellLevel.Length);
            foreach (var entry in SpellLevel)
            {
                writer.WriteSByte(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            MaxTaxCollectorsCount = reader.ReadSByte();
            TaxCollectorsCount = reader.ReadSByte();
            TaxCollectorLifePoints = reader.ReadShort();
            TaxCollectorDamagesBonuses = reader.ReadShort();
            TaxCollectorPods = reader.ReadShort();
            TaxCollectorProspecting = reader.ReadShort();
            TaxCollectorWisdom = reader.ReadShort();
            BoostPoints = reader.ReadShort();
            var limit = reader.ReadUShort();
            SpellId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellId[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            SpellLevel = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellLevel[i] = reader.ReadSByte();
            }
        }
    }
}