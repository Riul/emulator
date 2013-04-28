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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Spells
{
    public class SpellListMessage : NetworkMessage
    {
        public const uint ID = 1200;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool SpellPrevisualization { get; set; }
        public SpellItem[] Spells { get; set; }


        public SpellListMessage()
        {
        }

        public SpellListMessage(bool spellPrevisualization, SpellItem[] spells)
        {
            SpellPrevisualization = spellPrevisualization;
            Spells = spells;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(SpellPrevisualization);
            writer.WriteUShort((ushort) Spells.Length);
            foreach (var entry in Spells)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SpellPrevisualization = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            Spells = new SpellItem[limit];
            for (int i = 0; i < limit; i++)
            {
                Spells[i] = new SpellItem();
                Spells[i].Deserialize(reader);
            }
        }
    }
}