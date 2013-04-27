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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ObjectsAddedMessage : NetworkMessage
    {
        public const uint Id = 6033;

        public ObjectItem[] @object;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ObjectsAddedMessage()
        {
        }

        public ObjectsAddedMessage(ObjectItem[] @object)
        {
            this.@object = @object;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) @object.Length);
            foreach (var entry in @object)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            @object = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                @object[i] = new ObjectItem();
                @object[i].Deserialize(reader);
            }
        }
    }
}