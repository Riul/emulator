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

namespace Emulator.Common.Protocol.Net.Messages.Game.Interactive
{
    public class InteractiveUsedMessage : NetworkMessage
    {
        public const uint ID = 5745;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int EntityId { get; set; }
        public int ElemId { get; set; }
        public short SkillId { get; set; }
        public short Duration { get; set; }


        public InteractiveUsedMessage()
        {
        }

        public InteractiveUsedMessage(int entityId, int elemId, short skillId, short duration)
        {
            EntityId = entityId;
            ElemId = elemId;
            SkillId = skillId;
            Duration = duration;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(EntityId);
            writer.WriteInt(ElemId);
            writer.WriteShort(SkillId);
            writer.WriteShort(Duration);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            EntityId = reader.ReadInt();
            ElemId = reader.ReadInt();
            SkillId = reader.ReadShort();
            Duration = reader.ReadShort();
        }
    }
}