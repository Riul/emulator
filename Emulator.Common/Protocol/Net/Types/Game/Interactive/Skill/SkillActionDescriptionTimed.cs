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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive.Skill
{
    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public const short Id = 103;

        public byte time;

        public override short TypeId
        {
            get { return Id; }
        }


        public SkillActionDescriptionTimed()
        {
        }

        public SkillActionDescriptionTimed(short skillId, byte time)
            : base(skillId)
        {
            this.time = time;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(time);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            time = reader.ReadByte();
            if (time < 0 || time > 255)
                throw new Exception("Forbidden value on time = " + time + ", it doesn't respect the following condition : time < 0 || time > 255");
        }
    }
}