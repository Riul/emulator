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
    public class ExchangeStartOkTaxCollectorMessage : NetworkMessage
    {
        public const uint Id = 5780;

        public int collectorId;
        public int goldInfo;
        public ObjectItem[] objectsInfos;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ExchangeStartOkTaxCollectorMessage()
        {
        }

        public ExchangeStartOkTaxCollectorMessage(int collectorId, ObjectItem[] objectsInfos, int goldInfo)
        {
            this.collectorId = collectorId;
            this.objectsInfos = objectsInfos;
            this.goldInfo = goldInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(collectorId);
            writer.WriteUShort((ushort) objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                entry.Serialize(writer);
            }
            writer.WriteInt(goldInfo);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            collectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            objectsInfos = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                objectsInfos[i] = new ObjectItem();
                objectsInfos[i].Deserialize(reader);
            }
            goldInfo = reader.ReadInt();
            if (goldInfo < 0)
                throw new Exception("Forbidden value on goldInfo = " + goldInfo + ", it doesn't respect the following condition : goldInfo < 0");
        }
    }
}