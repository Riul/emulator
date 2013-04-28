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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultExperienceData : FightResultAdditionalData
    {
        public const short ID = 192;

        public override short TypeId
        {
            get { return ID; }
        }

        public bool ShowExperience { get; set; }
        public bool ShowExperienceLevelFloor { get; set; }
        public bool ShowExperienceNextLevelFloor { get; set; }
        public bool ShowExperienceFightDelta { get; set; }
        public bool ShowExperienceForGuild { get; set; }
        public bool ShowExperienceForMount { get; set; }
        public bool IsIncarnationExperience { get; set; }
        public double Experience { get; set; }
        public double ExperienceLevelFloor { get; set; }
        public double ExperienceNextLevelFloor { get; set; }
        public int ExperienceFightDelta { get; set; }
        public int ExperienceForGuild { get; set; }
        public int ExperienceForMount { get; set; }
        public int RerollExperienceMul { get; set; }


        public FightResultExperienceData()
        {
        }

        public FightResultExperienceData(bool showExperience, bool showExperienceLevelFloor, bool showExperienceNextLevelFloor, bool showExperienceFightDelta, bool showExperienceForGuild, bool showExperienceForMount, bool isIncarnationExperience, double experience, double experienceLevelFloor, double experienceNextLevelFloor, int experienceFightDelta, int experienceForGuild, int experienceForMount, int rerollExperienceMul)
        {
            ShowExperience = showExperience;
            ShowExperienceLevelFloor = showExperienceLevelFloor;
            ShowExperienceNextLevelFloor = showExperienceNextLevelFloor;
            ShowExperienceFightDelta = showExperienceFightDelta;
            ShowExperienceForGuild = showExperienceForGuild;
            ShowExperienceForMount = showExperienceForMount;
            IsIncarnationExperience = isIncarnationExperience;
            Experience = experience;
            ExperienceLevelFloor = experienceLevelFloor;
            ExperienceNextLevelFloor = experienceNextLevelFloor;
            ExperienceFightDelta = experienceFightDelta;
            ExperienceForGuild = experienceForGuild;
            ExperienceForMount = experienceForMount;
            RerollExperienceMul = rerollExperienceMul;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, ShowExperience);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, ShowExperienceLevelFloor);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, ShowExperienceNextLevelFloor);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, ShowExperienceFightDelta);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, ShowExperienceForGuild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 5, ShowExperienceForMount);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 6, IsIncarnationExperience);
            writer.WriteByte(flag1);
            writer.WriteDouble(Experience);
            writer.WriteDouble(ExperienceLevelFloor);
            writer.WriteDouble(ExperienceNextLevelFloor);
            writer.WriteInt(ExperienceFightDelta);
            writer.WriteInt(ExperienceForGuild);
            writer.WriteInt(ExperienceForMount);
            writer.WriteInt(RerollExperienceMul);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            ShowExperience = BooleanByteWrapper.GetFlag(flag1, 0);
            ShowExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag1, 1);
            ShowExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag1, 2);
            ShowExperienceFightDelta = BooleanByteWrapper.GetFlag(flag1, 3);
            ShowExperienceForGuild = BooleanByteWrapper.GetFlag(flag1, 4);
            ShowExperienceForMount = BooleanByteWrapper.GetFlag(flag1, 5);
            IsIncarnationExperience = BooleanByteWrapper.GetFlag(flag1, 6);
            Experience = reader.ReadDouble();
            ExperienceLevelFloor = reader.ReadDouble();
            ExperienceNextLevelFloor = reader.ReadDouble();
            ExperienceFightDelta = reader.ReadInt();
            ExperienceForGuild = reader.ReadInt();
            ExperienceForMount = reader.ReadInt();
            RerollExperienceMul = reader.ReadInt();
        }
    }
}