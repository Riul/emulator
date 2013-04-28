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
    public class MapCoordinatesAndId : MapCoordinates
    {
        public const short ID = 392;

        public override short TypeId
        {
            get { return ID; }
        }

        public int MapId { get; set; }


        public MapCoordinatesAndId()
        {
        }

        public MapCoordinatesAndId(short worldX, short worldY, int mapId)
                : base(worldX, worldY)
        {
            MapId = mapId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MapId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadInt();
        }
    }
}