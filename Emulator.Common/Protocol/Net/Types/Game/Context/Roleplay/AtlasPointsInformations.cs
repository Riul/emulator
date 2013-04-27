#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:46
// */
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


        public AtlasPointsInformations()
        {
        }

        public AtlasPointsInformations(sbyte type, MapCoordinatesExtended[] coords)
        {
            this.type = type;
            this.coords = coords;
        }

        public virtual short TypeId
        {
            get { return Id; }
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