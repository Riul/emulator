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
using Emulator.Common.Protocol.Net.Types.Game.Achievement;

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementListMessage : NetworkMessage
    {
        public const uint ID = 6205;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short[] FinishedAchievementsIds { get; set; }
        public AchievementRewardable[] RewardableAchievements { get; set; }


        public AchievementListMessage()
        {
        }

        public AchievementListMessage(short[] finishedAchievementsIds, AchievementRewardable[] rewardableAchievements)
        {
            FinishedAchievementsIds = finishedAchievementsIds;
            RewardableAchievements = rewardableAchievements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) FinishedAchievementsIds.Length);
            foreach (var entry in FinishedAchievementsIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) RewardableAchievements.Length);
            foreach (var entry in RewardableAchievements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            FinishedAchievementsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                FinishedAchievementsIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            RewardableAchievements = new AchievementRewardable[limit];
            for (int i = 0; i < limit; i++)
            {
                RewardableAchievements[i] = new AchievementRewardable();
                RewardableAchievements[i].Deserialize(reader);
            }
        }
    }
}