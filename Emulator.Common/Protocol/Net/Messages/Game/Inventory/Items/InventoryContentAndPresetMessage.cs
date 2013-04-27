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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class InventoryContentAndPresetMessage : InventoryContentMessage
    {
        public const uint Id = 6162;

        public Types.Game.Inventory.Preset.Preset[] presets;


        public InventoryContentAndPresetMessage()
        {
        }

        public InventoryContentAndPresetMessage(ObjectItem[] objects, int kamas, Types.Game.Inventory.Preset.Preset[] presets)
            : base(objects, kamas)
        {
            this.presets = presets;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) presets.Length);
            foreach (var entry in presets)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            presets = new Types.Game.Inventory.Preset.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                presets[i] = new Types.Game.Inventory.Preset.Preset();
                presets[i].Deserialize(reader);
            }
        }
    }
}