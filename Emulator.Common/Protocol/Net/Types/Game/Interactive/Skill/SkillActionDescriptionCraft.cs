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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionCraft : SkillActionDescription
    {
        public const short ID = 100;

        public override short TypeId
        {
            get { return ID; }
        }

        public sbyte MaxSlots { get; set; }
        public sbyte Probability { get; set; }


        public SkillActionDescriptionCraft()
        {
        }

        public SkillActionDescriptionCraft(short skillId, sbyte maxSlots, sbyte probability)
                : base(skillId)
        {
            MaxSlots = maxSlots;
            Probability = probability;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(MaxSlots);
            writer.WriteSByte(Probability);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MaxSlots = reader.ReadSByte();
            Probability = reader.ReadSByte();
        }
    }
}