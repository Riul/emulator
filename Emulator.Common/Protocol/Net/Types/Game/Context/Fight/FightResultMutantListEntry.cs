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
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public const short Id = 216;

        public ushort level;

        public override short TypeId
        {
            get { return Id; }
        }


        public FightResultMutantListEntry()
        {
        }

        public FightResultMutantListEntry(short outcome, FightLoot rewards, int id, bool alive, ushort level)
            : base(outcome, rewards, id, alive)
        {
            this.level = level;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(level);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadUShort();
            if (level < 0 || level > 65535)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 65535");
        }
    }
}