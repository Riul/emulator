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
    public class InventoryPresetItemUpdateErrorMessage : NetworkMessage
    {
        public const uint ID = 6211;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte Code { get; set; }


        public InventoryPresetItemUpdateErrorMessage()
        {
        }

        public InventoryPresetItemUpdateErrorMessage(sbyte code)
        {
            Code = code;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Code);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Code = reader.ReadSByte();
        }
    }
}