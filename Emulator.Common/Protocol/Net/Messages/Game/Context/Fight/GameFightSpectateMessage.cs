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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Fight
{
    public class GameFightSpectateMessage : NetworkMessage
    {
        public const uint ID = 6069;

        public override uint MessageId
        {
            get { return ID; }
        }

        public FightDispellableEffectExtendedInformations[] Effects { get; set; }
        public GameActionMark[] Marks { get; set; }
        public short GameTurn { get; set; }


        public GameFightSpectateMessage()
        {
        }

        public GameFightSpectateMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks, short gameTurn)
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort) Effects.Length);
            foreach (var entry in Effects)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) Marks.Length);
            foreach (var entry in Marks)
            {
                entry.Serialize(writer);
            }
            writer.WriteShort(GameTurn);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            Effects = new FightDispellableEffectExtendedInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Effects[i] = new FightDispellableEffectExtendedInformations();
                Effects[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            Marks = new GameActionMark[limit];
            for (int i = 0; i < limit; i++)
            {
                Marks[i] = new GameActionMark();
                Marks[i].Deserialize(reader);
            }
            GameTurn = reader.ReadShort();
        }
    }
}