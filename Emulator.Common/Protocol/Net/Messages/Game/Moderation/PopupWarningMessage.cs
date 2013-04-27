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

namespace Emulator.Common.Protocol.Net.Messages.Game.Moderation
{
    public class PopupWarningMessage : NetworkMessage
    {
        public const uint Id = 6134;

        public string author;
        public string content;
        public byte lockDuration;


        public PopupWarningMessage()
        {
        }

        public PopupWarningMessage(byte lockDuration, string author, string content)
        {
            this.lockDuration = lockDuration;
            this.author = author;
            this.content = content;
        }

        public override uint MessageId
        {
            get { return Id; }
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteByte(lockDuration);
            writer.WriteUTF(author);
            writer.WriteUTF(content);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            lockDuration = reader.ReadByte();
            if (lockDuration < 0 || lockDuration > 255)
                throw new Exception("Forbidden value on lockDuration = " + lockDuration + ", it doesn't respect the following condition : lockDuration < 0 || lockDuration > 255");
            author = reader.ReadUTF();
            content = reader.ReadUTF();
        }
    }
}