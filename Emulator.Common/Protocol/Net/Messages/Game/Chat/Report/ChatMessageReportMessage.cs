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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat.Report
{
    public class ChatMessageReportMessage : NetworkMessage
    {
        public const uint ID = 821;

        public override uint MessageId
        {
            get { return ID; }
        }

        public string SenderName { get; set; }
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public sbyte Channel { get; set; }
        public string Fingerprint { get; set; }
        public sbyte Reason { get; set; }


        public ChatMessageReportMessage()
        {
        }

        public ChatMessageReportMessage(string senderName, string content, int timestamp, sbyte channel, string fingerprint, sbyte reason)
        {
            SenderName = senderName;
            Content = content;
            Timestamp = timestamp;
            Channel = channel;
            Fingerprint = fingerprint;
            Reason = reason;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUTF(SenderName);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteSByte(Channel);
            writer.WriteUTF(Fingerprint);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SenderName = reader.ReadUTF();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Channel = reader.ReadSByte();
            Fingerprint = reader.ReadUTF();
            Reason = reader.ReadSByte();
        }
    }
}