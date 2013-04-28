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
using Emulator.Common.Protocol.Net.Types.Game.Interactive.Skill;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobDescription
    {
        public const short ID = 101;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte JobId { get; set; }
        public SkillActionDescription[] Skills { get; set; }


        public JobDescription()
        {
        }

        public JobDescription(sbyte jobId, SkillActionDescription[] skills)
        {
            JobId = jobId;
            Skills = skills;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteUShort((ushort) Skills.Length);
            foreach (var entry in Skills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            JobId = reader.ReadSByte();
            var limit = reader.ReadUShort();
            Skills = new SkillActionDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                Skills[i] = Types.ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadShort());
                Skills[i].Deserialize(reader);
            }
        }
    }
}