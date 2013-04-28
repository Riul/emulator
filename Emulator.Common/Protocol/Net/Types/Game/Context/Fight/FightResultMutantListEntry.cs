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
// Created on 28/04/2013 at 11:31

#endregion

using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public const short ID = 216;

        public override short TypeId
        {
            get { return ID; }
        }

        public ushort Level { get; set; }


        public FightResultMutantListEntry()
        {
        }

        public FightResultMutantListEntry(short outcome, FightLoot rewards, int id, bool alive, ushort level)
                : base(outcome, rewards, id, alive)
        {
            Level = level;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Level);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadUShort();
        }
    }
}