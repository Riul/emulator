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

namespace Emulator.Common.Protocol.Net.Types.Game.Achievement
{
    public class Achievement
    {
        public const short ID = 363;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short Id { get; set; }
        public AchievementObjective[] FinishedObjective { get; set; }
        public AchievementStartedObjective[] StartedObjectives { get; set; }


        public Achievement()
        {
        }

        public Achievement(short id, AchievementObjective[] finishedObjective, AchievementStartedObjective[] startedObjectives)
        {
            Id = id;
            FinishedObjective = finishedObjective;
            StartedObjectives = startedObjectives;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(Id);
            writer.WriteUShort((ushort) FinishedObjective.Length);
            foreach (var entry in FinishedObjective)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) StartedObjectives.Length);
            foreach (var entry in StartedObjectives)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Id = reader.ReadShort();
            var limit = reader.ReadUShort();
            FinishedObjective = new AchievementObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                FinishedObjective[i] = new AchievementObjective();
                FinishedObjective[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            StartedObjectives = new AchievementStartedObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                StartedObjectives[i] = new AchievementStartedObjective();
                StartedObjectives[i].Deserialize(reader);
            }
        }
    }
}