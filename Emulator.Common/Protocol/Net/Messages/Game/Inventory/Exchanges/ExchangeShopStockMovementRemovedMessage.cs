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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
    {
        public const uint Id = 5907;

        public int objectId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeShopStockMovementRemovedMessage()
        {
        }

        public ExchangeShopStockMovementRemovedMessage(int objectId)
        {
            this.objectId = objectId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(objectId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            objectId = reader.ReadInt();
            if (objectId < 0)
                throw new Exception("Forbidden value on objectId = " + objectId + ", it doesn't respect the following condition : objectId < 0");
        }
    }
}