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
using Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic;
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Spells
{
    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const uint ID = 6214;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int SummonerId { get; set; }
        public int SlaveId { get; set; }
        public SpellItem[] SlaveSpells { get; set; }
        public CharacterCharacteristicsInformations SlaveStats { get; set; }


        public SlaveSwitchContextMessage()
        {
        }

        public SlaveSwitchContextMessage(int summonerId, int slaveId, SpellItem[] slaveSpells, CharacterCharacteristicsInformations slaveStats)
        {
            SummonerId = summonerId;
            SlaveId = slaveId;
            SlaveSpells = slaveSpells;
            SlaveStats = slaveStats;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(SummonerId);
            writer.WriteInt(SlaveId);
            writer.WriteUShort((ushort) SlaveSpells.Length);
            foreach (var entry in SlaveSpells)
            {
                entry.Serialize(writer);
            }
            SlaveStats.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SummonerId = reader.ReadInt();
            SlaveId = reader.ReadInt();
            var limit = reader.ReadUShort();
            SlaveSpells = new SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                SlaveSpells[i] = new SpellItem();
                SlaveSpells[i].Deserialize(reader);
            }
            SlaveStats = new CharacterCharacteristicsInformations();
            SlaveStats.Deserialize(reader);
        }
    }
}