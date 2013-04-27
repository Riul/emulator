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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Items
{
    public class ObjectDeletedMessage : NetworkMessage
    {
        public const uint Id = 3024;

        public int objectUID;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ObjectDeletedMessage()
        {
        }

        public ObjectDeletedMessage(int objectUID)
        {
            this.objectUID = objectUID;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(objectUID);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
        }
    }
}