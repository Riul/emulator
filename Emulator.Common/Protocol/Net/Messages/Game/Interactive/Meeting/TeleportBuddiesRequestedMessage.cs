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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive.Meeting
{
    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        public const uint ID = 6302;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short DungeonId { get; set; }
        public int InviterId { get; set; }
        public int[] InvalidBuddiesIds { get; set; }


        public TeleportBuddiesRequestedMessage()
        {
        }

        public TeleportBuddiesRequestedMessage(short dungeonId, int inviterId, int[] invalidBuddiesIds)
        {
            DungeonId = dungeonId;
            InviterId = inviterId;
            InvalidBuddiesIds = invalidBuddiesIds;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(DungeonId);
            writer.WriteInt(InviterId);
            writer.WriteUShort((ushort) InvalidBuddiesIds.Length);
            foreach (var entry in InvalidBuddiesIds)
            {
                writer.WriteInt(entry);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            DungeonId = reader.ReadShort();
            InviterId = reader.ReadInt();
            var limit = reader.ReadUShort();
            InvalidBuddiesIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                InvalidBuddiesIds[i] = reader.ReadInt();
            }
        }
    }
}