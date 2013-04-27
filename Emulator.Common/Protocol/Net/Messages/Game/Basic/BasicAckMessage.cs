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

namespace Emulator.Common.Protocol.Net.Messages.Game.Basic
{
    public class BasicAckMessage : NetworkMessage
    {
        public const uint Id = 6362;

        public short lastPacketId;
        public int seq;

        public override uint MessageId
        {
            get { return Id; }
        }


        public BasicAckMessage()
        {
        }

        public BasicAckMessage(int seq, short lastPacketId)
        {
            this.seq = seq;
            this.lastPacketId = lastPacketId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(seq);
            writer.WriteShort(lastPacketId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            seq = reader.ReadInt();
            if (seq < 0)
                throw new Exception("Forbidden value on seq = " + seq + ", it doesn't respect the following condition : seq < 0");
            lastPacketId = reader.ReadShort();
            if (lastPacketId < 0)
                throw new Exception("Forbidden value on lastPacketId = " + lastPacketId + ", it doesn't respect the following condition : lastPacketId < 0");
        }
    }
}