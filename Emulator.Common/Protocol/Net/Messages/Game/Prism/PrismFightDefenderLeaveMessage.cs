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

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefenderLeaveMessage : NetworkMessage
    {
        public const uint Id = 5892;

        public double fightId;
        public int fighterToRemoveId;
        public int successor;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PrismFightDefenderLeaveMessage()
        {
        }

        public PrismFightDefenderLeaveMessage(double fightId, int fighterToRemoveId, int successor)
        {
            this.fightId = fightId;
            this.fighterToRemoveId = fighterToRemoveId;
            this.successor = successor;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(fighterToRemoveId);
            writer.WriteInt(successor);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            fighterToRemoveId = reader.ReadInt();
            if (fighterToRemoveId < 0)
                throw new Exception("Forbidden value on fighterToRemoveId = " + fighterToRemoveId + ", it doesn't respect the following condition : fighterToRemoveId < 0");
            successor = reader.ReadInt();
            if (successor < 0)
                throw new Exception("Forbidden value on successor = " + successor + ", it doesn't respect the following condition : successor < 0");
        }
    }
}