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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Zaap
{
    public class TeleportDestinationsListMessage : NetworkMessage
    {
        public const uint ID = 5960;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte TeleporterType { get; set; }
        public int[] MapIds { get; set; }
        public short[] SubAreaIds { get; set; }
        public short[] Costs { get; set; }


        public TeleportDestinationsListMessage()
        {
        }

        public TeleportDestinationsListMessage(sbyte teleporterType, int[] mapIds, short[] subAreaIds, short[] costs)
        {
            TeleporterType = teleporterType;
            MapIds = mapIds;
            SubAreaIds = subAreaIds;
            Costs = costs;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(TeleporterType);
            writer.WriteUShort((ushort) MapIds.Length);
            foreach (var entry in MapIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) SubAreaIds.Length);
            foreach (var entry in SubAreaIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) Costs.Length);
            foreach (var entry in Costs)
            {
                writer.WriteShort(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            TeleporterType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            MapIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                MapIds[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            SubAreaIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                SubAreaIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            Costs = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                Costs[i] = reader.ReadShort();
            }
        }
    }
}