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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeResultMessage : NetworkMessage
    {
        public const uint Id = 6019;

        public short challengeId;
        public bool success;

        public override uint MessageId
        {
            get { return Id; }
        }


        public ChallengeResultMessage()
        {
        }

        public ChallengeResultMessage(short challengeId, bool success)
        {
            this.challengeId = challengeId;
            this.success = success;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(challengeId);
            writer.WriteBoolean(success);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            challengeId = reader.ReadShort();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
            success = reader.ReadBoolean();
        }
    }
}