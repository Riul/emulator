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