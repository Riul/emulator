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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Web.Ankabox
{
    public class MailStatusMessage : NetworkMessage
    {
        public const uint ID = 6275;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short Unread { get; set; }
        public short Total { get; set; }


        public MailStatusMessage()
        {
        }

        public MailStatusMessage(short unread, short total)
        {
            Unread = unread;
            Total = total;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(Unread);
            writer.WriteShort(Total);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Unread = reader.ReadShort();
            Total = reader.ReadShort();
        }
    }
}