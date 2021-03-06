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

namespace Emulator.Common.Protocol.Net.Messages.Server.Basic
{
    public class SystemMessageDisplayMessage : NetworkMessage
    {
        public const uint ID = 189;

        public override uint MessageId
        {
            get { return ID; }
        }

        public bool HangUp { get; set; }
        public short MsgId { get; set; }
        public string[] Parameters { get; set; }


        public SystemMessageDisplayMessage()
        {
        }

        public SystemMessageDisplayMessage(bool hangUp, short msgId, string[] parameters)
        {
            HangUp = hangUp;
            MsgId = msgId;
            Parameters = parameters;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(HangUp);
            writer.WriteShort(MsgId);
            writer.WriteUShort((ushort) Parameters.Length);
            foreach (var entry in Parameters)
            {
                writer.WriteUTF(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            HangUp = reader.ReadBoolean();
            MsgId = reader.ReadShort();
            var limit = reader.ReadUShort();
            Parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                Parameters[i] = reader.ReadUTF();
            }
        }
    }
}