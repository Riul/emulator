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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultListEntry
    {
        public const short Id = 16;

        public short outcome;
        public FightLoot rewards;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public FightResultListEntry()
        {
        }

        public FightResultListEntry(short outcome, FightLoot rewards)
        {
            this.outcome = outcome;
            this.rewards = rewards;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(outcome);
            rewards.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            outcome = reader.ReadShort();
            if (outcome < 0)
                throw new Exception("Forbidden value on outcome = " + outcome + ", it doesn't respect the following condition : outcome < 0");
            rewards = new FightLoot();
            rewards.Deserialize(reader);
        }
    }
}