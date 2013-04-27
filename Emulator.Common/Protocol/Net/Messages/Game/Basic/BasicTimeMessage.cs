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

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicTimeMessage : NetworkMessage
    {
        public const uint Id = 175;

        public int timestamp;
        public short timezoneOffset;

        public override uint MessageId
        {
            get { return Id; }
        }


        public BasicTimeMessage()
        {
        }

        public BasicTimeMessage(int timestamp, short timezoneOffset)
        {
            this.timestamp = timestamp;
            this.timezoneOffset = timezoneOffset;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(timestamp);
            writer.WriteShort(timezoneOffset);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            timestamp = reader.ReadInt();
            if (timestamp < 0)
                throw new Exception("Forbidden value on timestamp = " + timestamp + ", it doesn't respect the following condition : timestamp < 0");
            timezoneOffset = reader.ReadShort();
        }
    }
}