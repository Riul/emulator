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

namespace Emulator.Common.Protocol.Net.Messages.Game.Character.Stats
{
    public class CharacterExperienceGainMessage : NetworkMessage
    {
        public const uint ID = 6321;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double ExperienceCharacter { get; set; }
        public double ExperienceMount { get; set; }
        public double ExperienceGuild { get; set; }
        public double ExperienceIncarnation { get; set; }


        public CharacterExperienceGainMessage()
        {
        }

        public CharacterExperienceGainMessage(double experienceCharacter, double experienceMount, double experienceGuild, double experienceIncarnation)
        {
            ExperienceCharacter = experienceCharacter;
            ExperienceMount = experienceMount;
            ExperienceGuild = experienceGuild;
            ExperienceIncarnation = experienceIncarnation;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(ExperienceCharacter);
            writer.WriteDouble(ExperienceMount);
            writer.WriteDouble(ExperienceGuild);
            writer.WriteDouble(ExperienceIncarnation);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ExperienceCharacter = reader.ReadDouble();
            ExperienceMount = reader.ReadDouble();
            ExperienceGuild = reader.ReadDouble();
            ExperienceIncarnation = reader.ReadDouble();
        }
    }
}