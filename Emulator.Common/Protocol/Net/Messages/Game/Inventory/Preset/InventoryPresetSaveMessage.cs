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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Preset
{
    public class InventoryPresetSaveMessage : NetworkMessage
    {
        public const uint Id = 6165;

        public sbyte presetId;
        public bool saveEquipment;
        public sbyte symbolId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public InventoryPresetSaveMessage()
        {
        }

        public InventoryPresetSaveMessage(sbyte presetId, sbyte symbolId, bool saveEquipment)
        {
            this.presetId = presetId;
            this.symbolId = symbolId;
            this.saveEquipment = saveEquipment;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(presetId);
            writer.WriteSByte(symbolId);
            writer.WriteBoolean(saveEquipment);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            symbolId = reader.ReadSByte();
            if (symbolId < 0)
                throw new Exception("Forbidden value on symbolId = " + symbolId + ", it doesn't respect the following condition : symbolId < 0");
            saveEquipment = reader.ReadBoolean();
        }
    }
}