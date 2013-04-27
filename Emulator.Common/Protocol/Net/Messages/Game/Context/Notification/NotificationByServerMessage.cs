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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Notification
{
    public class NotificationByServerMessage : NetworkMessage
    {
        public const uint Id = 6103;
        public bool forceOpen;

        public ushort id;
        public string[] parameters;

        public override uint MessageId
        {
            get { return Id; }
        }


        public NotificationByServerMessage()
        {
        }

        public NotificationByServerMessage(ushort id, string[] parameters, bool forceOpen)
        {
            this.id = id;
            this.parameters = parameters;
            this.forceOpen = forceOpen;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort(id);
            writer.WriteUShort((ushort) parameters.Length);
            foreach (var entry in parameters)
            {
                writer.WriteUTF(entry);
            }
            writer.WriteBoolean(forceOpen);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadUShort();
            if (id < 0 || id > 65535)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0 || id > 65535");
            var limit = reader.ReadUShort();
            parameters = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                parameters[i] = reader.ReadUTF();
            }
            forceOpen = reader.ReadBoolean();
        }
    }
}