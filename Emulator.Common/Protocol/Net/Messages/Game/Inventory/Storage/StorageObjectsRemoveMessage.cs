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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Storage
{
    public class StorageObjectsRemoveMessage : NetworkMessage
    {
        public const uint ID = 6035;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int[] ObjectUIDList { get; set; }


        public StorageObjectsRemoveMessage()
        {
        }

        public StorageObjectsRemoveMessage(int[] objectUIDList)
        {
            ObjectUIDList = objectUIDList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ObjectUIDList.Length);
            foreach (var entry in ObjectUIDList)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ObjectUIDList = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectUIDList[i] = reader.ReadInt();
            }
        }
    }
}