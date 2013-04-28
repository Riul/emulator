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

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightAttackedMessage : NetworkMessage
    {
        public const uint ID = 5894;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public short SubAreaId { get; set; }
        public sbyte PrismSide { get; set; }


        public PrismFightAttackedMessage()
        {
        }

        public PrismFightAttackedMessage(short worldX, short worldY, int mapId, short subAreaId, sbyte prismSide)
        {
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            PrismSide = prismSide;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteShort(SubAreaId);
            writer.WriteSByte(PrismSide);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadShort();
            PrismSide = reader.ReadSByte();
        }
    }
}