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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Sequence
{
    public class SequenceEndMessage : NetworkMessage
    {
        public const uint ID = 956;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short ActionId { get; set; }
        public int AuthorId { get; set; }
        public sbyte SequenceType { get; set; }


        public SequenceEndMessage()
        {
        }

        public SequenceEndMessage(short actionId, int authorId, sbyte sequenceType)
        {
            ActionId = actionId;
            AuthorId = authorId;
            SequenceType = sequenceType;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(ActionId);
            writer.WriteInt(AuthorId);
            writer.WriteSByte(SequenceType);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            ActionId = reader.ReadShort();
            AuthorId = reader.ReadInt();
            SequenceType = reader.ReadSByte();
        }
    }
}