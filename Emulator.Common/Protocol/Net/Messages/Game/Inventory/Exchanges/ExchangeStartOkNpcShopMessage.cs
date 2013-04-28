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
    public class ExchangeStartOkNpcShopMessage : NetworkMessage
    {
        public const uint ID = 5761;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int NpcSellerId { get; set; }
        public int TokenId { get; set; }
        public ObjectItemToSellInNpcShop[] ObjectsInfos { get; set; }


        public ExchangeStartOkNpcShopMessage()
        {
        }

        public ExchangeStartOkNpcShopMessage(int npcSellerId, int tokenId, ObjectItemToSellInNpcShop[] objectsInfos)
        {
            NpcSellerId = npcSellerId;
            TokenId = tokenId;
            ObjectsInfos = objectsInfos;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(NpcSellerId);
            writer.WriteInt(TokenId);
            writer.WriteUShort((ushort) ObjectsInfos.Length);
            foreach (var entry in ObjectsInfos)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            NpcSellerId = reader.ReadInt();
            TokenId = reader.ReadInt();
            var limit = reader.ReadUShort();
            ObjectsInfos = new ObjectItemToSellInNpcShop[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectsInfos[i] = new ObjectItemToSellInNpcShop();
                ObjectsInfos[i].Deserialize(reader);
            }
        }
    }
}