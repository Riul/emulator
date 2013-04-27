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

namespace Emulator.Common.Protocol.Net.Messages.Web.Ankabox
{
    public class NewMailMessage : MailStatusMessage
    {
        public const uint Id = 6292;

        public int[] sendersAccountId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public NewMailMessage()
        {
        }

        public NewMailMessage(short unread, short total, int[] sendersAccountId)
            : base(unread, total)
        {
            this.sendersAccountId = sendersAccountId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) sendersAccountId.Length);
            foreach (var entry in sendersAccountId)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            sendersAccountId = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                sendersAccountId[i] = reader.ReadInt();
            }
        }
    }
}