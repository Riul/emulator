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
// Created on 26/04/2013 at 16:45
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Handshake
{
    public class ProtocolRequired : NetworkMessage
    {
        public const uint Id = 1;

        public int currentVersion;
        public int requiredVersion;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(requiredVersion);
            writer.WriteInt(currentVersion);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            requiredVersion = reader.ReadInt();
            if (requiredVersion < 0)
                throw new Exception("Forbidden value on requiredVersion = " + requiredVersion + ", it doesn't respect the following condition : requiredVersion < 0");
            currentVersion = reader.ReadInt();
            if (currentVersion < 0)
                throw new Exception("Forbidden value on currentVersion = " + currentVersion + ", it doesn't respect the following condition : currentVersion < 0");
        }
    }
}