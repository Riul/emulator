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
    public class BasicLatencyStatsMessage : NetworkMessage
    {
        public const uint ID = 5663;

        public override uint MessageId
        {
            get { return ID; }
        }

        public ushort Latency { get; set; }
        public short SampleCount { get; set; }
        public short Max { get; set; }


        public BasicLatencyStatsMessage()
        {
        }

        public BasicLatencyStatsMessage(ushort latency, short sampleCount, short max)
        {
            Latency = latency;
            SampleCount = sampleCount;
            Max = max;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort(Latency);
            writer.WriteShort(SampleCount);
            writer.WriteShort(Max);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            Latency = reader.ReadUShort();
            SampleCount = reader.ReadShort();
            Max = reader.ReadShort();
        }
    }
}