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
    public class SkillActionDescription
    {
        public const short Id = 102;

        public short skillId;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public SkillActionDescription()
        {
        }

        public SkillActionDescription(short skillId)
        {
            this.skillId = skillId;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(skillId);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
        }
    }
}