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
    public class TeleportToBuddyOfferMessage : NetworkMessage
    {
        public const uint Id = 6287;

        public int buddyId;
        public short dungeonId;
        public int timeLeft;

        public override uint MessageId
        {
            get { return Id; }
        }


        public TeleportToBuddyOfferMessage()
        {
        }

        public TeleportToBuddyOfferMessage(short dungeonId, int buddyId, int timeLeft)
        {
            this.dungeonId = dungeonId;
            this.buddyId = buddyId;
            this.timeLeft = timeLeft;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(dungeonId);
            writer.WriteInt(buddyId);
            writer.WriteInt(timeLeft);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            buddyId = reader.ReadInt();
            if (buddyId < 0)
                throw new Exception("Forbidden value on buddyId = " + buddyId + ", it doesn't respect the following condition : buddyId < 0");
            timeLeft = reader.ReadInt();
            if (timeLeft < 0)
                throw new Exception("Forbidden value on timeLeft = " + timeLeft + ", it doesn't respect the following condition : timeLeft < 0");
        }
    }
}