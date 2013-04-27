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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Sequence
{
    public class SequenceEndMessage : NetworkMessage
    {
        public const uint Id = 956;

        public short actionId;
        public int authorId;
        public sbyte sequenceType;

        public override uint MessageId
        {
            get { return Id; }
        }


        public SequenceEndMessage()
        {
        }

        public SequenceEndMessage(short actionId, int authorId, sbyte sequenceType)
        {
            this.actionId = actionId;
            this.authorId = authorId;
            this.sequenceType = sequenceType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(actionId);
            writer.WriteInt(authorId);
            writer.WriteSByte(sequenceType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            authorId = reader.ReadInt();
            sequenceType = reader.ReadSByte();
        }
    }
}