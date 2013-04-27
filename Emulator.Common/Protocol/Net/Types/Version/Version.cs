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
    public class Version
    {
        public const short Id = 11;
        public sbyte buildType;

        public sbyte major;
        public sbyte minor;
        public sbyte patch;
        public sbyte release;
        public int revision;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public Version()
        {
        }

        public Version(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType)
        {
            this.major = major;
            this.minor = minor;
            this.release = release;
            this.revision = revision;
            this.patch = patch;
            this.buildType = buildType;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(major);
            writer.WriteSByte(minor);
            writer.WriteSByte(release);
            writer.WriteInt(revision);
            writer.WriteSByte(patch);
            writer.WriteSByte(buildType);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            major = reader.ReadSByte();
            if (major < 0)
                throw new Exception("Forbidden value on major = " + major + ", it doesn't respect the following condition : major < 0");
            minor = reader.ReadSByte();
            if (minor < 0)
                throw new Exception("Forbidden value on minor = " + minor + ", it doesn't respect the following condition : minor < 0");
            release = reader.ReadSByte();
            if (release < 0)
                throw new Exception("Forbidden value on release = " + release + ", it doesn't respect the following condition : release < 0");
            revision = reader.ReadInt();
            if (revision < 0)
                throw new Exception("Forbidden value on revision = " + revision + ", it doesn't respect the following condition : revision < 0");
            patch = reader.ReadSByte();
            if (patch < 0)
                throw new Exception("Forbidden value on patch = " + patch + ", it doesn't respect the following condition : patch < 0");
            buildType = reader.ReadSByte();
            if (buildType < 0)
                throw new Exception("Forbidden value on buildType = " + buildType + ", it doesn't respect the following condition : buildType < 0");
        }
    }
}