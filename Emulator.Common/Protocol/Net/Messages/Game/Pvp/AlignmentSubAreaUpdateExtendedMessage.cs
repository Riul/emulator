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

namespace Emulator.Common.Protocol.Net.Messages.Game.Pvp
{
    public class AlignmentSubAreaUpdateExtendedMessage : AlignmentSubAreaUpdateMessage
    {
        public const uint ID = 6319;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public sbyte EventType { get; set; }


        public AlignmentSubAreaUpdateExtendedMessage()
        {
        }

        public AlignmentSubAreaUpdateExtendedMessage(short subAreaId, sbyte side, bool quiet, short worldX, short worldY, int mapId, sbyte eventType)
                : base(subAreaId, side, quiet)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            EventType = eventType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteSByte(EventType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            EventType = reader.ReadSByte();
        }
    }
}