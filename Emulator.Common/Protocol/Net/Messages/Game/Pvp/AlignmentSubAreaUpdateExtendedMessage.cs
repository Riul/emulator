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

namespace Emulator.Common.Protocol.Net.Messages.Game.Pvp
{
    public class AlignmentSubAreaUpdateExtendedMessage : AlignmentSubAreaUpdateMessage
    {
        public const uint Id = 6319;
        public sbyte eventType;
        public int mapId;

        public short worldX;
        public short worldY;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AlignmentSubAreaUpdateExtendedMessage()
        {
        }

        public AlignmentSubAreaUpdateExtendedMessage(short subAreaId, sbyte side, bool quiet, short worldX, short worldY, int mapId, sbyte eventType)
            : base(subAreaId, side, quiet)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.eventType = eventType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteSByte(eventType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            eventType = reader.ReadSByte();
        }
    }
}