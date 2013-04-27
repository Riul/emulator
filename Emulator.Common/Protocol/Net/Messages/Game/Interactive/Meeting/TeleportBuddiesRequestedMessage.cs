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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Meeting
{
    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        public const uint Id = 6302;

        public short dungeonId;
        public int[] invalidBuddiesIds;
        public int inviterId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public TeleportBuddiesRequestedMessage()
        {
        }

        public TeleportBuddiesRequestedMessage(short dungeonId, int inviterId, int[] invalidBuddiesIds)
        {
            this.dungeonId = dungeonId;
            this.inviterId = inviterId;
            this.invalidBuddiesIds = invalidBuddiesIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(dungeonId);
            writer.WriteInt(inviterId);
            writer.WriteUShort((ushort) invalidBuddiesIds.Length);
            foreach (var entry in invalidBuddiesIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            inviterId = reader.ReadInt();
            if (inviterId < 0)
                throw new Exception("Forbidden value on inviterId = " + inviterId + ", it doesn't respect the following condition : inviterId < 0");
            var limit = reader.ReadUShort();
            invalidBuddiesIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                invalidBuddiesIds[i] = reader.ReadInt();
            }
        }
    }
}