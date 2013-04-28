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

namespace Emulator.Common.Protocol.Net.Messages.Game.Approach
{
    public class AccountLoggingKickedMessage : NetworkMessage
    {
        public const uint ID = 6029;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }


        public AccountLoggingKickedMessage()
        {
        }

        public AccountLoggingKickedMessage(int days, int hours, int minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Days);
            writer.WriteInt(Hours);
            writer.WriteInt(Minutes);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Days = reader.ReadInt();
            Hours = reader.ReadInt();
            Minutes = reader.ReadInt();
        }
    }
}