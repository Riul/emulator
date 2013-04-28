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
    public class GameFightResumeSlaveInfo
    {
        public const short ID = 364;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int SlaveId { get; set; }
        public GameFightSpellCooldown[] SpellCooldowns { get; set; }
        public sbyte SummonCount { get; set; }
        public sbyte BombCount { get; set; }


        public GameFightResumeSlaveInfo()
        {
        }

        public GameFightResumeSlaveInfo(int slaveId, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount)
        {
            SlaveId = slaveId;
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(SlaveId);
            writer.WriteUShort((ushort) SpellCooldowns.Length);
            foreach (var entry in SpellCooldowns)
            {
                entry.Serialize(writer);
            }
            writer.WriteSByte(SummonCount);
            writer.WriteSByte(BombCount);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            SlaveId = reader.ReadInt();
            var limit = reader.ReadUShort();
            SpellCooldowns = new GameFightSpellCooldown[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellCooldowns[i] = new GameFightSpellCooldown();
                SpellCooldowns[i].Deserialize(reader);
            }
            SummonCount = reader.ReadSByte();
            BombCount = reader.ReadSByte();
        }
    }
}