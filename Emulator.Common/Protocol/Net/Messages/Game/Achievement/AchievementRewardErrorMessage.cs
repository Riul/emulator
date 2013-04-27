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

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementRewardErrorMessage : NetworkMessage
    {
        public const uint Id = 6375;

        public short achievementId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AchievementRewardErrorMessage()
        {
        }

        public AchievementRewardErrorMessage(short achievementId)
        {
            this.achievementId = achievementId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(achievementId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            achievementId = reader.ReadShort();
        }
    }
}