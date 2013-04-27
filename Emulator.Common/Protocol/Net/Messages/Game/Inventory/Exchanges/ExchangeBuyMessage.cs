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
    public class ExchangeBuyMessage : NetworkMessage
    {
        public const uint Id = 5774;

        public int objectToBuyId;
        public int quantity;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeBuyMessage()
        {
        }

        public ExchangeBuyMessage(int objectToBuyId, int quantity)
        {
            this.objectToBuyId = objectToBuyId;
            this.quantity = quantity;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(objectToBuyId);
            writer.WriteInt(quantity);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            objectToBuyId = reader.ReadInt();
            if (objectToBuyId < 0)
                throw new Exception("Forbidden value on objectToBuyId = " + objectToBuyId + ", it doesn't respect the following condition : objectToBuyId < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
        }
    }
}