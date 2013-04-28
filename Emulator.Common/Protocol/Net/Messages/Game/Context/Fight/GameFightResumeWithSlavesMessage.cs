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
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public const uint ID = 6215;

        public override uint MessageId
        {
            get { return ID; }
        }

        public GameFightResumeSlaveInfo[] SlavesInfo { get; set; }


        public GameFightResumeWithSlavesMessage()
        {
        }

        public GameFightResumeWithSlavesMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks, short gameTurn, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount, GameFightResumeSlaveInfo[] slavesInfo)
                : base(effects, marks, gameTurn, spellCooldowns, summonCount, bombCount)
        {
            SlavesInfo = slavesInfo;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort((ushort) SlavesInfo.Length);
            foreach (var entry in SlavesInfo)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadUShort();
            SlavesInfo = new GameFightResumeSlaveInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                SlavesInfo[i] = new GameFightResumeSlaveInfo();
                SlavesInfo[i].Deserialize(reader);
            }
        }
    }
}