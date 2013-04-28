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
    public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
    {
        public const uint ID = 5762;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string CollectorName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public string UserName { get; set; }
        public double Experience { get; set; }
        public ObjectItemQuantity[] ObjectsInfos { get; set; }


        public ExchangeGuildTaxCollectorGetMessage()
        {
        }

        public ExchangeGuildTaxCollectorGetMessage(string collectorName, short worldX, short worldY, int mapId, short subAreaId, string userName, double experience, ObjectItemQuantity[] objectsInfos)
        {
            CollectorName = collectorName;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            UserName = userName;
            Experience = experience;
            ObjectsInfos = objectsInfos;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(CollectorName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteUTF(UserName);
            writer.WriteDouble(Experience);
            writer.WriteUShort((ushort) ObjectsInfos.Length);
            foreach (var entry in ObjectsInfos)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            CollectorName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            UserName = reader.ReadUTF();
            Experience = reader.ReadDouble();
            var limit = reader.ReadUShort();
            ObjectsInfos = new ObjectItemQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                ObjectsInfos[i] = new ObjectItemQuantity();
                ObjectsInfos[i].Deserialize(reader);
            }
        }
    }
}