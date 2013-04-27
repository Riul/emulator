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

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Chat
{
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public const uint Id = 881;
        public int senderAccountId;

        public int senderId;
        public string senderName;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ChatServerMessage()
        {
        }

        public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, int senderId, string senderName, int senderAccountId)
            : base(channel, content, timestamp, fingerprint)
        {
            this.senderId = senderId;
            this.senderName = senderName;
            this.senderAccountId = senderAccountId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(senderId);
            writer.WriteUTF(senderName);
            writer.WriteInt(senderAccountId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            senderId = reader.ReadInt();
            senderName = reader.ReadUTF();
            senderAccountId = reader.ReadInt();
        }
    }
}