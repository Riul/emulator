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
using Emulator.Common.Protocol.Net.Types.Game.Action.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Actions.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Context.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public const uint ID = 6067;

        public override uint MessageId
        {
            get { return ID; }
        }

        public GameFightSpellCooldown[] SpellCooldowns { get; set; }
        public sbyte SummonCount { get; set; }
        public sbyte BombCount { get; set; }


        public GameFightResumeMessage()
        {
        }

        public GameFightResumeMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks, short gameTurn, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount)
                : base(effects, marks, gameTurn)
        {
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) SpellCooldowns.Length);
            foreach (var entry in SpellCooldowns)
            {
                entry.Serialize(writer);
            }
            writer.WriteSByte(SummonCount);
            writer.WriteSByte(BombCount);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
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