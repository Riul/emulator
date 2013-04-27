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
    public class ObjectFoundWhileRecoltingMessage : NetworkMessage
    {
        public const uint Id = 6017;

        public int genericId;
        public int quantity;
        public int ressourceGenericId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ObjectFoundWhileRecoltingMessage()
        {
        }

        public ObjectFoundWhileRecoltingMessage(int genericId, int quantity, int ressourceGenericId)
        {
            this.genericId = genericId;
            this.quantity = quantity;
            this.ressourceGenericId = ressourceGenericId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(genericId);
            writer.WriteInt(quantity);
            writer.WriteInt(ressourceGenericId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            genericId = reader.ReadInt();
            if (genericId < 0)
                throw new Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
            ressourceGenericId = reader.ReadInt();
            if (ressourceGenericId < 0)
                throw new Exception("Forbidden value on ressourceGenericId = " + ressourceGenericId + ", it doesn't respect the following condition : ressourceGenericId < 0");
        }
    }
}