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
    public class ChatServerCopyMessage : ChatAbstractServerMessage
    {
        public const uint ID = 882;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }


        public ChatServerCopyMessage()
        {
        }

        public ChatServerCopyMessage(sbyte channel, string content, int timestamp, string fingerprint, int receiverId, string receiverName)
                : base(channel, content, timestamp, fingerprint)
        {
            ReceiverId = receiverId;
            ReceiverName = receiverName;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ReceiverId);
            writer.WriteUTF(ReceiverName);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            ReceiverId = reader.ReadInt();
            ReceiverName = reader.ReadUTF();
        }
    }
}