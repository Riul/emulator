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
    public class InventoryPresetItemUpdateRequestMessage : NetworkMessage
    {
        public const uint ID = 6210;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PresetId { get; set; }
        public byte Position { get; set; }
        public int ObjUid { get; set; }


        public InventoryPresetItemUpdateRequestMessage()
        {
        }

        public InventoryPresetItemUpdateRequestMessage(sbyte presetId, byte position, int objUid)
        {
            PresetId = presetId;
            Position = position;
            ObjUid = objUid;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(PresetId);
            writer.WriteByte(Position);
            writer.WriteInt(ObjUid);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PresetId = reader.ReadSByte();
            Position = reader.ReadByte();
            ObjUid = reader.ReadInt();
        }
    }
}