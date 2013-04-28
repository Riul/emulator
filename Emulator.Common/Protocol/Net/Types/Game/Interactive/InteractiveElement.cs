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

namespace Emulator.Common.Protocol.Net.Types.Game.Interactive
{
    public class InteractiveElement
    {
        public const short ID = 80;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public InteractiveElementSkill[] EnabledSkills { get; set; }
        public InteractiveElementSkill[] DisabledSkills { get; set; }


        public InteractiveElement()
        {
        }

        public InteractiveElement(int elementId, int elementTypeId, InteractiveElementSkill[] enabledSkills, InteractiveElementSkill[] disabledSkills)
        {
            ElementId = elementId;
            ElementTypeId = elementTypeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteInt(ElementTypeId);
            writer.WriteUShort((ushort) EnabledSkills.Length);
            foreach (var entry in EnabledSkills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) DisabledSkills.Length);
            foreach (var entry in DisabledSkills)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ElementId = reader.ReadInt();
            ElementTypeId = reader.ReadInt();
            var limit = reader.ReadUShort();
            EnabledSkills = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                EnabledSkills[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                EnabledSkills[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            DisabledSkills = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                DisabledSkills[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                DisabledSkills[i].Deserialize(reader);
            }
        }
    }
}