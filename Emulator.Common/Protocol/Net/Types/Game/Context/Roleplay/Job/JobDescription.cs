#region License
// /*
//    Copyright (C) 2013 Phito
// 
//    This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created on 26/04/2013 at 16:46
// */
#endregion

using System;
using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Interactive.Skill;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Roleplay.Job
{
    public class JobDescription
    {
        public const short Id = 101;

        public sbyte jobId;
        public SkillActionDescription[] skills;


        public JobDescription()
        {
        }

        public JobDescription(sbyte jobId, SkillActionDescription[] skills)
        {
            this.jobId = jobId;
            this.skills = skills;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteUShort((ushort) skills.Length);
            foreach (var entry in skills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            var limit = reader.ReadUShort();
            skills = new SkillActionDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                skills[i] = Types.ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadShort());
                skills[i].Deserialize(reader);
            }
        }
    }
}