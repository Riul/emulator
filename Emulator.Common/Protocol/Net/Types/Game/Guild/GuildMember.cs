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
using Emulator.Common.Protocol.Net.Types.Game.Character;
using Emulator.Common.Protocol.Net.Types.Game.Character.Status;

namespace Emulator.Common.Protocol.Net.Types.Game.Guild
{
    public class GuildMember : CharacterMinimalInformations
    {
        public const short ID = 88;

        public override short TypeId
        {
            get { return ID; }
        }

        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public short Rank { get; set; }
        public double GivenExperience { get; set; }
        public sbyte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }
        public sbyte Connected { get; set; }
        public sbyte AlignmentSide { get; set; }
        public ushort HoursSinceLastConnection { get; set; }
        public sbyte MoodSmileyId { get; set; }
        public int AccountId { get; set; }
        public int AchievementPoints { get; set; }
        public PlayerStatus Status { get; set; }


        public GuildMember()
        {
        }

        public GuildMember(int id, byte level, string name, sbyte breed, bool sex, short rank, double givenExperience, sbyte experienceGivenPercent, uint rights, sbyte connected, sbyte alignmentSide, ushort hoursSinceLastConnection, sbyte moodSmileyId, int accountId, int achievementPoints, PlayerStatus status)
                : base(id, level, name)
        {
            Breed = breed;
            Sex = sex;
            Rank = rank;
            GivenExperience = givenExperience;
            ExperienceGivenPercent = experienceGivenPercent;
            Rights = rights;
            Connected = connected;
            AlignmentSide = alignmentSide;
            HoursSinceLastConnection = hoursSinceLastConnection;
            MoodSmileyId = moodSmileyId;
            AccountId = accountId;
            AchievementPoints = achievementPoints;
            Status = status;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteShort(Rank);
            writer.WriteDouble(GivenExperience);
            writer.WriteSByte(ExperienceGivenPercent);
            writer.WriteUInt(Rights);
            writer.WriteSByte(Connected);
            writer.WriteSByte(AlignmentSide);
            writer.WriteUShort(HoursSinceLastConnection);
            writer.WriteSByte(MoodSmileyId);
            writer.WriteInt(AccountId);
            writer.WriteInt(AchievementPoints);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Rank = reader.ReadShort();
            GivenExperience = reader.ReadDouble();
            ExperienceGivenPercent = reader.ReadSByte();
            Rights = reader.ReadUInt();
            Connected = reader.ReadSByte();
            AlignmentSide = reader.ReadSByte();
            HoursSinceLastConnection = reader.ReadUShort();
            MoodSmileyId = reader.ReadSByte();
            AccountId = reader.ReadInt();
            AchievementPoints = reader.ReadInt();
            Status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
        }
    }
}