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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class AtlasPointsInformations
    {
        public const short ID = 175;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte Type { get; set; }
        public MapCoordinatesExtended[] Coords { get; set; }


        public AtlasPointsInformations()
        {
        }

        public AtlasPointsInformations(sbyte type, MapCoordinatesExtended[] coords)
        {
            Type = type;
            Coords = coords;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteUShort((ushort) Coords.Length);
            foreach (var entry in Coords)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Type = reader.ReadSByte();
            var limit = reader.ReadUShort();
            Coords = new MapCoordinatesExtended[limit];
            for (int i = 0; i < limit; i++)
            {
                Coords[i] = new MapCoordinatesExtended();
                Coords[i].Deserialize(reader);
            }
        }
    }
}