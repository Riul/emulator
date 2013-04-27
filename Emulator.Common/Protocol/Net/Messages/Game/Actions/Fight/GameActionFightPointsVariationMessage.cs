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
    public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
    {
        public const uint Id = 1030;

        public short delta;
        public int targetId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameActionFightPointsVariationMessage()
        {
        }

        public GameActionFightPointsVariationMessage(short actionId, int sourceId, int targetId, short delta)
            : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.delta = delta;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(delta);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            delta = reader.ReadShort();
        }
    }
}