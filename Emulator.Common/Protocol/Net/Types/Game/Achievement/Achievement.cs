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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Achievement
{
    public class Achievement
    {
        public const short Id = 363;

        public AchievementObjective[] finishedObjective;
        public short id;
        public AchievementStartedObjective[] startedObjectives;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public Achievement()
        {
        }

        public Achievement(short id, AchievementObjective[] finishedObjective, AchievementStartedObjective[] startedObjectives)
        {
            this.id = id;
            this.finishedObjective = finishedObjective;
            this.startedObjectives = startedObjectives;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(id);
            writer.WriteUShort((ushort) finishedObjective.Length);
            foreach (var entry in finishedObjective)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) startedObjectives.Length);
            foreach (var entry in startedObjectives)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            id = reader.ReadShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            var limit = reader.ReadUShort();
            finishedObjective = new AchievementObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                finishedObjective[i] = new AchievementObjective();
                finishedObjective[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            startedObjectives = new AchievementStartedObjective[limit];
            for (int i = 0; i < limit; i++)
            {
                startedObjectives[i] = new AchievementStartedObjective();
                startedObjectives[i].Deserialize(reader);
            }
        }
    }
}