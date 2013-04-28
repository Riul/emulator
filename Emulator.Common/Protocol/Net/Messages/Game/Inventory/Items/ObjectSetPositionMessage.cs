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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ObjectSetPositionMessage : NetworkMessage
    {
        public const uint ID = 3021;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int ObjectUID { get; set; }
        public byte Position { get; set; }
        public int Quantity { get; set; }


        public ObjectSetPositionMessage()
        {
        }

        public ObjectSetPositionMessage(int objectUID, byte position, int quantity)
        {
            ObjectUID = objectUID;
            Position = position;
            Quantity = quantity;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ObjectUID);
            writer.WriteByte(Position);
            writer.WriteInt(Quantity);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ObjectUID = reader.ReadInt();
            Position = reader.ReadByte();
            Quantity = reader.ReadInt();
        }
    }
}