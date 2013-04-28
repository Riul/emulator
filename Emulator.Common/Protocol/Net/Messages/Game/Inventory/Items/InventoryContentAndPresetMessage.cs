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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class InventoryContentAndPresetMessage : InventoryContentMessage
    {
        public const uint ID = 6162;

        public override uint MessageId
        {
            get { return ID; }
        }

        public Types.Game.Inventory.Preset.Preset[] Presets { get; set; }


        public InventoryContentAndPresetMessage()
        {
        }

        public InventoryContentAndPresetMessage(ObjectItem[] objects, int kamas, Types.Game.Inventory.Preset.Preset[] presets)
                : base(objects, kamas)
        {
            Presets = presets;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) Presets.Length);
            foreach (var entry in Presets)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            Presets = new Types.Game.Inventory.Preset.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                Presets[i] = new Types.Game.Inventory.Preset.Preset();
                Presets[i].Deserialize(reader);
            }
        }
    }
}