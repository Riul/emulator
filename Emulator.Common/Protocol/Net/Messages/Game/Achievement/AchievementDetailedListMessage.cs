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
    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const uint Id = 6358;

        public Types.Game.Achievement.Achievement[] finishedAchievements;
        public Types.Game.Achievement.Achievement[] startedAchievements;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AchievementDetailedListMessage()
        {
        }

        public AchievementDetailedListMessage(Types.Game.Achievement.Achievement[] startedAchievements, Types.Game.Achievement.Achievement[] finishedAchievements)
        {
            this.startedAchievements = startedAchievements;
            this.finishedAchievements = finishedAchievements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) startedAchievements.Length);
            foreach (var entry in startedAchievements)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) finishedAchievements.Length);
            foreach (var entry in finishedAchievements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            startedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                startedAchievements[i] = new Types.Game.Achievement.Achievement();
                startedAchievements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            finishedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedAchievements[i] = new Types.Game.Achievement.Achievement();
                finishedAchievements[i].Deserialize(reader);
            }
        }
    }
}