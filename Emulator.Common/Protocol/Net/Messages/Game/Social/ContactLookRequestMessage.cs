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

namespace Emulator.Common.Protocol.Net.Messages.Game.Social
{
    public class ContactLookRequestMessage : NetworkMessage
    {
        public const uint Id = 5932;

        public sbyte contactType;
        public byte requestId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ContactLookRequestMessage()
        {
        }

        public ContactLookRequestMessage(byte requestId, sbyte contactType)
        {
            this.requestId = requestId;
            this.contactType = contactType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteByte(requestId);
            writer.WriteSByte(contactType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            requestId = reader.ReadByte();
            if (requestId < 0 || requestId > 255)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0 || requestId > 255");
            contactType = reader.ReadSByte();
            if (contactType < 0)
                throw new Exception("Forbidden value on contactType = " + contactType + ", it doesn't respect the following condition : contactType < 0");
        }
    }
}