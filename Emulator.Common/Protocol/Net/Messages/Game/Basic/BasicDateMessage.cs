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
    public class BasicDateMessage : NetworkMessage
    {
        public const uint Id = 177;

        public sbyte day;
        public sbyte month;
        public short year;

        public override uint MessageId
        {
            get { return Id; }
        }


        public BasicDateMessage()
        {
        }

        public BasicDateMessage(sbyte day, sbyte month, short year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(day);
            writer.WriteSByte(month);
            writer.WriteShort(year);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            day = reader.ReadSByte();
            if (day < 0)
                throw new Exception("Forbidden value on day = " + day + ", it doesn't respect the following condition : day < 0");
            month = reader.ReadSByte();
            if (month < 0)
                throw new Exception("Forbidden value on month = " + month + ", it doesn't respect the following condition : month < 0");
            year = reader.ReadShort();
            if (year < 0)
                throw new Exception("Forbidden value on year = " + year + ", it doesn't respect the following condition : year < 0");
        }
    }
}