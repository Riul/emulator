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
    public class ObjectsDeletedMessage : NetworkMessage
    {
        public const uint ID = 6034;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int[] ObjectUID { get; set; }


        public ObjectsDeletedMessage()
        {
        }

        public ObjectsDeletedMessage(int[] objectUID)
        {
            ObjectUID = objectUID;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ObjectUID.Length);
            foreach (var entry in ObjectUID)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ObjectUID = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectUID[i] = reader.ReadInt();
            }
        }
    }
}