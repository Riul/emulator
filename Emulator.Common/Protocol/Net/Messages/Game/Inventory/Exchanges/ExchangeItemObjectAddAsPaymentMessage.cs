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
    public class ExchangeItemObjectAddAsPaymentMessage : NetworkMessage
    {
        public const uint ID = 5766;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte PaymentType { get; set; }
        public bool BAdd { get; set; }
        public int ObjectToMoveId { get; set; }
        public int Quantity { get; set; }


        public ExchangeItemObjectAddAsPaymentMessage()
        {
        }

        public ExchangeItemObjectAddAsPaymentMessage(sbyte paymentType, bool bAdd, int objectToMoveId, int quantity)
        {
            PaymentType = paymentType;
            BAdd = bAdd;
            ObjectToMoveId = objectToMoveId;
            Quantity = quantity;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(PaymentType);
            writer.WriteBoolean(BAdd);
            writer.WriteInt(ObjectToMoveId);
            writer.WriteInt(Quantity);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            PaymentType = reader.ReadSByte();
            BAdd = reader.ReadBoolean();
            ObjectToMoveId = reader.ReadInt();
            Quantity = reader.ReadInt();
        }
    }
}