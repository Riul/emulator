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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay
{
    public class AtlasPointsInformations
    {
        public const short Id = 175;

        public MapCoordinatesExtended[] coords;
        public sbyte type;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public AtlasPointsInformations()
        {
        }

        public AtlasPointsInformations(sbyte type, MapCoordinatesExtended[] coords)
        {
            this.type = type;
            this.coords = coords;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteUShort((ushort) coords.Length);
            foreach (var entry in coords)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            var limit = reader.ReadUShort();
            coords = new MapCoordinatesExtended[limit];
            for (int i = 0; i < limit; i++)
            {
                coords[i] = new MapCoordinatesExtended();
                coords[i].Deserialize(reader);
            }
        }
    }
}