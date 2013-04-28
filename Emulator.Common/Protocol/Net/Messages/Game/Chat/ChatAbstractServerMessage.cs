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

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat
{
    public class ChatAbstractServerMessage : NetworkMessage
    {
        public const uint ID = 880;

        public override uint MessageId
        {
            get { return ID; }
        }

        public sbyte Channel { get; set; }
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public string Fingerprint { get; set; }


        public ChatAbstractServerMessage()
        {
        }

        public ChatAbstractServerMessage(sbyte channel, string content, int timestamp, string fingerprint)
        {
            Channel = channel;
            Content = content;
            Timestamp = timestamp;
            Fingerprint = fingerprint;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(Channel);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteUTF(Fingerprint);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Channel = reader.ReadSByte();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Fingerprint = reader.ReadUTF();
        }
    }
}