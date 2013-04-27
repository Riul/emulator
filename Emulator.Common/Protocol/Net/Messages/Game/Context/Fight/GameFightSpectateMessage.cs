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
using Emulator.Common.Protocol.Net.Types.Game.Action.Fight;
using Emulator.Common.Protocol.Net.Types.Game.Actions.Fight;

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightSpectateMessage : NetworkMessage
    {
        public const uint Id = 6069;

        public FightDispellableEffectExtendedInformations[] effects;
        public short gameTurn;
        public GameActionMark[] marks;

        public override uint MessageId
        {
            get { return Id; }
        }


        public GameFightSpectateMessage()
        {
        }

        public GameFightSpectateMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks, short gameTurn)
        {
            this.effects = effects;
            this.marks = marks;
            this.gameTurn = gameTurn;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) effects.Length);
            foreach (var entry in effects)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) marks.Length);
            foreach (var entry in marks)
            {
                entry.Serialize(writer);
            }
            writer.WriteShort(gameTurn);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            effects = new FightDispellableEffectExtendedInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                effects[i] = new FightDispellableEffectExtendedInformations();
                effects[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            marks = new GameActionMark[limit];
            for (int i = 0; i < limit; i++)
            {
                marks[i] = new GameActionMark();
                marks[i].Deserialize(reader);
            }
            gameTurn = reader.ReadShort();
            if (gameTurn < 0)
                throw new Exception("Forbidden value on gameTurn = " + gameTurn + ", it doesn't respect the following condition : gameTurn < 0");
        }
    }
}