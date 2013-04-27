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
using Emulator.Common.Protocol.Net.Types.Game.Achievement;

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementListMessage : NetworkMessage
    {
        public const uint Id = 6205;

        public short[] finishedAchievementsIds;
        public AchievementRewardable[] rewardableAchievements;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AchievementListMessage()
        {
        }

        public AchievementListMessage(short[] finishedAchievementsIds, AchievementRewardable[] rewardableAchievements)
        {
            this.finishedAchievementsIds = finishedAchievementsIds;
            this.rewardableAchievements = rewardableAchievements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) finishedAchievementsIds.Length);
            foreach (var entry in finishedAchievementsIds)
            {
                writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort) rewardableAchievements.Length);
            foreach (var entry in rewardableAchievements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            finishedAchievementsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedAchievementsIds[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            rewardableAchievements = new AchievementRewardable[limit];
            for (int i = 0; i < limit; i++)
            {
                rewardableAchievements[i] = new AchievementRewardable();
                rewardableAchievements[i].Deserialize(reader);
            }
        }
    }
}