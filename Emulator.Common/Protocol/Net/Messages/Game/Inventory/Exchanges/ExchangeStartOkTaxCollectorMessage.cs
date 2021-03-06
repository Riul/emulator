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
    public class ExchangeStartOkTaxCollectorMessage : NetworkMessage
    {
        public const uint ID = 5780;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int CollectorId { get; set; }
        public ObjectItem[] ObjectsInfos { get; set; }
        public int GoldInfo { get; set; }


        public ExchangeStartOkTaxCollectorMessage()
        {
        }

        public ExchangeStartOkTaxCollectorMessage(int collectorId, ObjectItem[] objectsInfos, int goldInfo)
        {
            CollectorId = collectorId;
            ObjectsInfos = objectsInfos;
            GoldInfo = goldInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(CollectorId);
            writer.WriteUShort((ushort) ObjectsInfos.Length);
            foreach (var entry in ObjectsInfos)
            {
                entry.Serialize(writer);
            }
            writer.WriteInt(GoldInfo);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            CollectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            ObjectsInfos = new ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectsInfos[i] = new ObjectItem();
                ObjectsInfos[i].Deserialize(reader);
            }
            GoldInfo = reader.ReadInt();
        }
    }
}