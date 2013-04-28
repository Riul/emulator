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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicDateMessage : NetworkMessage
    {
        public const uint ID = 177;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte Day { get; set; }
        public sbyte Month { get; set; }
        public short Year { get; set; }


        public BasicDateMessage()
        {
        }

        public BasicDateMessage(sbyte day, sbyte month, short year)
        {
            Day = day;
            Month = month;
            Year = year;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Day);
            writer.WriteSByte(Month);
            writer.WriteShort(Year);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Day = reader.ReadSByte();
            Month = reader.ReadSByte();
            Year = reader.ReadShort();
        }
    }
}