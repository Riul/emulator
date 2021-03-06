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
    public class ObjectsQuantityMessage : NetworkMessage
    {
        public const uint ID = 6206;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ObjectItemQuantity[] ObjectsUIDAndQty { get; set; }


        public ObjectsQuantityMessage()
        {
        }

        public ObjectsQuantityMessage(ObjectItemQuantity[] objectsUIDAndQty)
        {
            ObjectsUIDAndQty = objectsUIDAndQty;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ObjectsUIDAndQty.Length);
            foreach (var entry in ObjectsUIDAndQty)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ObjectsUIDAndQty = new ObjectItemQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectsUIDAndQty[i] = new ObjectItemQuantity();
                ObjectsUIDAndQty[i].Deserialize(reader);
            }
        }
    }
}