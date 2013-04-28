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
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public const uint ID = 881;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int SenderAccountId { get; set; }


        public ChatServerMessage()
        {
        }

        public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, int senderId, string senderName, int senderAccountId)
                : base(channel, content, timestamp, fingerprint)
        {
            SenderId = senderId;
            SenderName = senderName;
            SenderAccountId = senderAccountId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(SenderId);
            writer.WriteUTF(SenderName);
            writer.WriteInt(SenderAccountId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            SenderId = reader.ReadInt();
            SenderName = reader.ReadUTF();
            SenderAccountId = reader.ReadInt();
        }
    }
}