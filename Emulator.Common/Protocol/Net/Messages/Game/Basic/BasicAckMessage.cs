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

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicAckMessage : NetworkMessage
    {
        public const uint ID = 6362;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int Seq { get; set; }
        public short LastPacketId { get; set; }


        public BasicAckMessage()
        {
        }

        public BasicAckMessage(int seq, short lastPacketId)
        {
            Seq = seq;
            LastPacketId = lastPacketId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(Seq);
            writer.WriteShort(LastPacketId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Seq = reader.ReadInt();
            LastPacketId = reader.ReadShort();
        }
    }
}