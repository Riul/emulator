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

namespace Emulator.Common.Protocol.Net.Messages.Game.Achievement
{
    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const uint ID = 6358;

        public override uint MessageId
        {
            get { return ID; }
        }

        public Types.Game.Achievement.Achievement[] StartedAchievements { get; set; }
        public Types.Game.Achievement.Achievement[] FinishedAchievements { get; set; }


        public AchievementDetailedListMessage()
        {
        }

        public AchievementDetailedListMessage(Types.Game.Achievement.Achievement[] startedAchievements, Types.Game.Achievement.Achievement[] finishedAchievements)
        {
            StartedAchievements = startedAchievements;
            FinishedAchievements = finishedAchievements;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) StartedAchievements.Length);
            foreach (var entry in StartedAchievements)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) FinishedAchievements.Length);
            foreach (var entry in FinishedAchievements)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            StartedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                StartedAchievements[i] = new Types.Game.Achievement.Achievement();
                StartedAchievements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            FinishedAchievements = new Types.Game.Achievement.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                FinishedAchievements[i] = new Types.Game.Achievement.Achievement();
                FinishedAchievements[i].Deserialize(reader);
            }
        }
    }
}