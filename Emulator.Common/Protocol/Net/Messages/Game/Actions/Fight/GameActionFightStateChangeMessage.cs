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
// Created on 26/04/2013 at 16:45
#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightStateChangeMessage : AbstractGameActionMessage
    {
        public const uint Id = 5569;

        public bool active;
        public short stateId;
        public int targetId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameActionFightStateChangeMessage()
        {
        }

        public GameActionFightStateChangeMessage(short actionId, int sourceId, int targetId, short stateId, bool active)
            : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.stateId = stateId;
            this.active = active;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(stateId);
            writer.WriteBoolean(active);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            stateId = reader.ReadShort();
            active = reader.ReadBoolean();
        }
    }
}