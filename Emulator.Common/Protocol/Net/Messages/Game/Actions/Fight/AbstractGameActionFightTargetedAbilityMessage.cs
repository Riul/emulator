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

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public const uint Id = 6118;

        public sbyte critical;
        public short destinationCellId;
        public bool silentCast;
        public int targetId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }

        public AbstractGameActionFightTargetedAbilityMessage(short actionId, int sourceId, int targetId, short destinationCellId, sbyte critical, bool silentCast)
            : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.destinationCellId = destinationCellId;
            this.critical = critical;
            this.silentCast = silentCast;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(destinationCellId);
            writer.WriteSByte(critical);
            writer.WriteBoolean(silentCast);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            destinationCellId = reader.ReadShort();
            if (destinationCellId < -1 || destinationCellId > 559)
                throw new Exception("Forbidden value on destinationCellId = " + destinationCellId + ", it doesn't respect the following condition : destinationCellId < -1 || destinationCellId > 559");
            critical = reader.ReadSByte();
            if (critical < 0)
                throw new Exception("Forbidden value on critical = " + critical + ", it doesn't respect the following condition : critical < 0");
            silentCast = reader.ReadBoolean();
        }
    }
}