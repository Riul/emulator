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
    public class VersionExtended : Version
    {
        public const short ID = 393;

        public override short TypeId
        {
            get { return ID; }
        }

        public sbyte Install { get; set; }
        public sbyte Technology { get; set; }


        public VersionExtended()
        {
        }

        public VersionExtended(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType, sbyte install, sbyte technology)
                : base(major, minor, release, revision, patch, buildType)
        {
            Install = install;
            Technology = technology;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Install);
            writer.WriteSByte(Technology);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadSByte();
            Technology = reader.ReadSByte();
        }
    }
}