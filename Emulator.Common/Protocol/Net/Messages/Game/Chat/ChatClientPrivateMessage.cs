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
    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public const uint Id = 851;

        public string receiver;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ChatClientPrivateMessage()
        {
        }

        public ChatClientPrivateMessage(string content, string receiver)
            : base(content)
        {
            this.receiver = receiver;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(receiver);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            receiver = reader.ReadUTF();
        }
    }
}