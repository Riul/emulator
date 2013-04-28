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

namespace Emulator.Common.Protocol.Net.Types.Version
{
    public class Version
    {
        public const short ID = 11;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte Major { get; set; }
        public sbyte Minor { get; set; }
        public sbyte Release { get; set; }
        public int Revision { get; set; }
        public sbyte Patch { get; set; }
        public sbyte BuildType { get; set; }


        public Version()
        {
        }

        public Version(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType)
        {
            Major = major;
            Minor = minor;
            Release = release;
            Revision = revision;
            Patch = patch;
            BuildType = buildType;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Major);
            writer.WriteSByte(Minor);
            writer.WriteSByte(Release);
            writer.WriteInt(Revision);
            writer.WriteSByte(Patch);
            writer.WriteSByte(BuildType);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Major = reader.ReadSByte();
            Minor = reader.ReadSByte();
            Release = reader.ReadSByte();
            Revision = reader.ReadInt();
            Patch = reader.ReadSByte();
            BuildType = reader.ReadSByte();
        }
    }
}