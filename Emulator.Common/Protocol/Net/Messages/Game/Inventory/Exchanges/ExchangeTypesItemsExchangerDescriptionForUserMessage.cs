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

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const uint Id = 5752;

        public BidExchangerObjectInfo[] itemTypeDescriptions;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(BidExchangerObjectInfo[] itemTypeDescriptions)
        {
            this.itemTypeDescriptions = itemTypeDescriptions;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) itemTypeDescriptions.Length);
            foreach (var entry in itemTypeDescriptions)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            itemTypeDescriptions = new BidExchangerObjectInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                itemTypeDescriptions[i] = new BidExchangerObjectInfo();
                itemTypeDescriptions[i].Deserialize(reader);
            }
        }
    }
}