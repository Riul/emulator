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

namespace Emulator.Common.Protocol.Net.Types.Version
{
    public class VersionExtended : Version
    {
        public const short Id = 393;

        public sbyte install;
        public sbyte technology;


        public VersionExtended()
        {
        }

        public VersionExtended(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType, sbyte install, sbyte technology)
            : base(major, minor, release, revision, patch, buildType)
        {
            this.install = install;
            this.technology = technology;
        }

        public override short TypeId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(install);
            writer.WriteSByte(technology);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            install = reader.ReadSByte();
            if (install < 0)
                throw new Exception("Forbidden value on install = " + install + ", it doesn't respect the following condition : install < 0");
            technology = reader.ReadSByte();
            if (technology < 0)
                throw new Exception("Forbidden value on technology = " + technology + ", it doesn't respect the following condition : technology < 0");
        }

        public override string ToString()
        {
            return major + "." + minor + "." + patch + "." + release + "." + revision;
        }
    }
}