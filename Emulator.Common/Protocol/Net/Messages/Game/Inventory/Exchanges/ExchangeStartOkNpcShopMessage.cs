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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items;

namespace Emulator.Common.Protocol.Net.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkNpcShopMessage : NetworkMessage
    {
        public const uint Id = 5761;

        public int npcSellerId;
        public ObjectItemToSellInNpcShop[] objectsInfos;
        public int tokenId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeStartOkNpcShopMessage()
        {
        }

        public ExchangeStartOkNpcShopMessage(int npcSellerId, int tokenId, ObjectItemToSellInNpcShop[] objectsInfos)
        {
            this.npcSellerId = npcSellerId;
            this.tokenId = tokenId;
            this.objectsInfos = objectsInfos;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(npcSellerId);
            writer.WriteInt(tokenId);
            writer.WriteUShort((ushort) objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            npcSellerId = reader.ReadInt();
            tokenId = reader.ReadInt();
            if (tokenId < 0)
                throw new Exception("Forbidden value on tokenId = " + tokenId + ", it doesn't respect the following condition : tokenId < 0");
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItemToSellInNpcShop[limit];
            for (int i = 0; i < limit; i++)
            {
                objectsInfos[i] = new ObjectItemToSellInNpcShop();
                objectsInfos[i].Deserialize(reader);
            }
        }
    }
}