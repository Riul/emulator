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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive
{
    public class InteractiveElement
    {
        public const short Id = 80;
        public InteractiveElementSkill[] disabledSkills;

        public int elementId;
        public int elementTypeId;
        public InteractiveElementSkill[] enabledSkills;

        public virtual short TypeId
        {
            get { return Id; }
        }


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