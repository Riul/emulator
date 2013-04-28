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

namespace Emulator.Common.Protocol.Net.Types.Game.Context
{
    public class MapCoordinates
    {
        public const short ID = 174;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short WorldX { get; set; }
        public short WorldY { get; set; }


        public MapCoordinates()
        {
        }

        public MapCoordinates(short worldX, short worldY)
        {
            WorldX = worldX;
            WorldY = worldY;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}