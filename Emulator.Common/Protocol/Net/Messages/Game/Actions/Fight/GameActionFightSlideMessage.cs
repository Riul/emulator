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
    public class GameActionFightSlideMessage : AbstractGameActionMessage
    {
        public const uint Id = 5525;

        public short endCellId;
        public short startCellId;
        public int targetId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameActionFightSlideMessage()
        {
        }

        public GameActionFightSlideMessage(short actionId, int sourceId, int targetId, short startCellId, short endCellId)
            : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.startCellId = startCellId;
            this.endCellId = endCellId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(startCellId);
            writer.WriteShort(endCellId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            startCellId = reader.ReadShort();
            if (startCellId < -1 || startCellId > 559)
                throw new Exception("Forbidden value on startCellId = " + startCellId + ", it doesn't respect the following condition : startCellId < -1 || startCellId > 559");
            endCellId = reader.ReadShort();
            if (endCellId < -1 || endCellId > 559)
                throw new Exception("Forbidden value on endCellId = " + endCellId + ", it doesn't respect the following condition : endCellId < -1 || endCellId > 559");
        }
    }
}