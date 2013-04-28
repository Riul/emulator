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
    public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
    {
        public const uint ID = 5772;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int HumanVendorId { get; set; }
        public int HumanVendorCell { get; set; }


        public ExchangeOnHumanVendorRequestMessage()
        {
        }

        public ExchangeOnHumanVendorRequestMessage(int humanVendorId, int humanVendorCell)
        {
            HumanVendorId = humanVendorId;
            HumanVendorCell = humanVendorCell;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(HumanVendorId);
            writer.WriteInt(HumanVendorCell);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            HumanVendorId = reader.ReadInt();
            HumanVendorCell = reader.ReadInt();
        }
    }
}