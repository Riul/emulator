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
// Created on 28/04/2013 at 11:30

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeInfoMessage : NetworkMessage
    {
        public const uint ID = 6022;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short ChallengeId { get; set; }
        public int TargetId { get; set; }
        public int XpBonus { get; set; }
        public int DropBonus { get; set; }


        public ChallengeInfoMessage()
        {
        }

        public ChallengeInfoMessage(short challengeId, int targetId, int xpBonus, int dropBonus)
        {
            ChallengeId = challengeId;
            TargetId = targetId;
            XpBonus = xpBonus;
            DropBonus = dropBonus;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ChallengeId);
            writer.WriteInt(TargetId);
            writer.WriteInt(XpBonus);
            writer.WriteInt(DropBonus);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ChallengeId = reader.ReadShort();
            TargetId = reader.ReadInt();
            XpBonus = reader.ReadInt();
            DropBonus = reader.ReadInt();
        }
    }
}