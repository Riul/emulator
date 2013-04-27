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

namespace Emulator.Common.Protocol.Net.Messages.Web.Ankabox
{
    public class MailStatusMessage : NetworkMessage
    {
        public const uint Id = 6275;

        public short total;
        public short unread;

        public override uint MessageId
        {
            get { return Id; }
        }


        public MailStatusMessage()
        {
        }

        public MailStatusMessage(short unread, short total)
        {
            this.unread = unread;
            this.total = total;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(unread);
            writer.WriteShort(total);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            unread = reader.ReadShort();
            if (unread < 0)
                throw new Exception("Forbidden value on unread = " + unread + ", it doesn't respect the following condition : unread < 0");
            total = reader.ReadShort();
            if (total < 0)
                throw new Exception("Forbidden value on total = " + total + ", it doesn't respect the following condition : total < 0");
        }
    }
}