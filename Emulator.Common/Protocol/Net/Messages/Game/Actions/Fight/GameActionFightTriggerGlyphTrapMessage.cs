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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
    {
        public const uint ID = 5741;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short MarkId { get; set; }
        public int TriggeringCharacterId { get; set; }
        public short TriggeredSpellId { get; set; }


        public GameActionFightTriggerGlyphTrapMessage()
        {
        }

        public GameActionFightTriggerGlyphTrapMessage(short actionId, int sourceId, short markId, int triggeringCharacterId, short triggeredSpellId)
                : base(actionId, sourceId)
        {
            MarkId = markId;
            TriggeringCharacterId = triggeringCharacterId;
            TriggeredSpellId = triggeredSpellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteInt(TriggeringCharacterId);
            writer.WriteShort(TriggeredSpellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            TriggeringCharacterId = reader.ReadInt();
            TriggeredSpellId = reader.ReadShort();
        }
    }
}