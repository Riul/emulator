#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:45
// */
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


        public ExchangeStartOkNpcShopMessage()
        {
        }

        public ExchangeStartOkNpcShopMessage(int npcSellerId, int tokenId, ObjectItemToSellInNpcShop[] objectsInfos)
        {
            this.npcSellerId = npcSellerId;
            this.tokenId = tokenId;
            this.objectsInfos = objectsInfos;
        }

        public override uint MessageId
        {
            get { return Id; }
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