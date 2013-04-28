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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const uint ID = 5752;

        public override uint MessageId
        {
            get { return ID; }
        }

        public BidExchangerObjectInfo[] ItemTypeDescriptions { get; set; }


        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(BidExchangerObjectInfo[] itemTypeDescriptions)
        {
            ItemTypeDescriptions = itemTypeDescriptions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) ItemTypeDescriptions.Length);
            foreach (var entry in ItemTypeDescriptions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            ItemTypeDescriptions = new BidExchangerObjectInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                ItemTypeDescriptions[i] = new BidExchangerObjectInfo();
                ItemTypeDescriptions[i].Deserialize(reader);
            }
        }
    }
}