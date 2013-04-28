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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Storage
{
    public class StorageObjectsUpdateMessage : NetworkMessage
    {
        public const uint ID = 6036;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ObjectItem[] ObjectList { get; set; }


        public StorageObjectsUpdateMessage()
        {
        }

        public StorageObjectsUpdateMessage(ObjectItem[] objectList)
        {
            ObjectList = objectList;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ObjectList.Length);
            foreach (var entry in ObjectList)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ObjectList = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectList[i] = new ObjectItem();
                ObjectList[i].Deserialize(reader);
            }
        }
    }
}