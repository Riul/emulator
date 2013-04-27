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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Stats
{
    public class StatsUpgradeRequestMessage : NetworkMessage
    {
        public const uint Id = 5610;

        public short boostPoint;
        public sbyte statId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public StatsUpgradeRequestMessage()
        {
        }

        public StatsUpgradeRequestMessage(sbyte statId, short boostPoint)
        {
            this.statId = statId;
            this.boostPoint = boostPoint;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(statId);
            writer.WriteShort(boostPoint);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            statId = reader.ReadSByte();
            if (statId < 0)
                throw new Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
        }
    }
}