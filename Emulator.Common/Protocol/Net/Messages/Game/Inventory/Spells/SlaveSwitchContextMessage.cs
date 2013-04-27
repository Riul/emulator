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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic;
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Spells
{
    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const uint Id = 6214;

        public int slaveId;
        public SpellItem[] slaveSpells;
        public CharacterCharacteristicsInformations slaveStats;
        public int summonerId;


        public SlaveSwitchContextMessage()
        {
        }

        public SlaveSwitchContextMessage(int summonerId, int slaveId, SpellItem[] slaveSpells, CharacterCharacteristicsInformations slaveStats)
        {
            this.summonerId = summonerId;
            this.slaveId = slaveId;
            this.slaveSpells = slaveSpells;
            this.slaveStats = slaveStats;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(summonerId);
            writer.WriteInt(slaveId);
            writer.WriteUShort((ushort) slaveSpells.Length);
            foreach (var entry in slaveSpells)
            {
                entry.Serialize(writer);
            }
            slaveStats.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            summonerId = reader.ReadInt();
            slaveId = reader.ReadInt();
            var limit = reader.ReadUShort();
            slaveSpells = new SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                slaveSpells[i] = new SpellItem();
                slaveSpells[i].Deserialize(reader);
            }
            slaveStats = new CharacterCharacteristicsInformations();
            slaveStats.Deserialize(reader);
        }
    }
}