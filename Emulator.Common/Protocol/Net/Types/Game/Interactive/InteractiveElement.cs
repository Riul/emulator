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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive
{
    public class InteractiveElement
    {
        public const short Id = 80;
        public InteractiveElementSkill[] disabledSkills;

        public int elementId;
        public int elementTypeId;
        public InteractiveElementSkill[] enabledSkills;


        public InteractiveElement()
        {
        }

        public InteractiveElement(int elementId, int elementTypeId, InteractiveElementSkill[] enabledSkills, InteractiveElementSkill[] disabledSkills)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
        }

        public virtual short TypeId
        {
            get { return Id; }
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteInt(elementTypeId);
            writer.WriteUShort((ushort) enabledSkills.Length);
            foreach (var entry in enabledSkills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) disabledSkills.Length);
            foreach (var entry in disabledSkills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementTypeId = reader.ReadInt();
            var limit = reader.ReadUShort();
            enabledSkills = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                enabledSkills[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                enabledSkills[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            disabledSkills = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                disabledSkills[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                disabledSkills[i].Deserialize(reader);
            }
        }
    }
}