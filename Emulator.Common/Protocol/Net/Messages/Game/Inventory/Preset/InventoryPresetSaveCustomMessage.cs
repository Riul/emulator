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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Preset
{
    public class InventoryPresetSaveCustomMessage : NetworkMessage
    {
        public const uint ID = 6329;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PresetId { get; set; }
        public sbyte SymbolId { get; set; }
        public byte[] ItemsPositions { get; set; }
        public int[] ItemsUids { get; set; }


        public InventoryPresetSaveCustomMessage()
        {
        }

        public InventoryPresetSaveCustomMessage(sbyte presetId, sbyte symbolId, byte[] itemsPositions, int[] itemsUids)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            ItemsPositions = itemsPositions;
            ItemsUids = itemsUids;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(PresetId);
            writer.WriteSByte(SymbolId);
            writer.WriteUShort((ushort) ItemsPositions.Length);
            foreach (var entry in ItemsPositions)
            {
                writer.WriteByte(entry);
            }
            writer.WriteUShort((ushort) ItemsUids.Length);
            foreach (var entry in ItemsUids)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PresetId = reader.ReadSByte();
            SymbolId = reader.ReadSByte();
            var limit = reader.ReadUShort();
            ItemsPositions = new byte[limit];
            for (int i = 0; i < limit; i++)
            {
                ItemsPositions[i] = reader.ReadByte();
            }
            limit = reader.ReadUShort();
            ItemsUids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ItemsUids[i] = reader.ReadInt();
            }
        }
    }
}