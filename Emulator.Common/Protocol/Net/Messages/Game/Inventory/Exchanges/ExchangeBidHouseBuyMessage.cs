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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const uint ID = 5804;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Uid { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }


        public ExchangeBidHouseBuyMessage()
        {
        }

        public ExchangeBidHouseBuyMessage(int uid, int qty, int price)
        {
            Uid = uid;
            Qty = qty;
            Price = price;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Uid);
            writer.WriteInt(Qty);
            writer.WriteInt(Price);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Uid = reader.ReadInt();
            Qty = reader.ReadInt();
            Price = reader.ReadInt();
        }
    }
}