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
    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const uint Id = 5755;

        public int averagePrice;
        public int genericId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeBidPriceMessage()
        {
        }

        public ExchangeBidPriceMessage(int genericId, int averagePrice)
        {
            this.genericId = genericId;
            this.averagePrice = averagePrice;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(genericId);
            writer.WriteInt(averagePrice);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            genericId = reader.ReadInt();
            if (genericId < 0)
                throw new Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            averagePrice = reader.ReadInt();
            if (averagePrice < 0)
                throw new Exception("Forbidden value on averagePrice = " + averagePrice + ", it doesn't respect the following condition : averagePrice < 0");
        }
    }
}