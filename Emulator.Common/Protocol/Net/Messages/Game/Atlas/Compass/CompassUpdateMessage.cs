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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Atlas.Compass
{
    public class CompassUpdateMessage : NetworkMessage
    {
        public const uint ID = 5591;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte Type { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }


        public CompassUpdateMessage()
        {
        }

        public CompassUpdateMessage(sbyte type, short worldX, short worldY)
        {
            Type = type;
            WorldX = worldX;
            WorldY = worldY;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Type = reader.ReadSByte();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}