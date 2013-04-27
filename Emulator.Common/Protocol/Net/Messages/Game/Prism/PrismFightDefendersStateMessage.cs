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

using Emulator.Common.IO;
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefendersStateMessage : NetworkMessage
    {
        public const uint Id = 5899;

        public double fightId;
        public CharacterMinimalPlusLookAndGradeInformations[] mainFighters;
        public CharacterMinimalPlusLookAndGradeInformations[] reserveFighters;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PrismFightDefendersStateMessage()
        {
        }

        public PrismFightDefendersStateMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations[] mainFighters, CharacterMinimalPlusLookAndGradeInformations[] reserveFighters)
        {
            this.fightId = fightId;
            this.mainFighters = mainFighters;
            this.reserveFighters = reserveFighters;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort) mainFighters.Length);
            foreach (var entry in mainFighters)
            {
                entry.Serialize(writer);
            }
            writer.WriteUShort((ushort) reserveFighters.Length);
            foreach (var entry in reserveFighters)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            mainFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                mainFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                mainFighters[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            reserveFighters = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                reserveFighters[i] = new CharacterMinimalPlusLookAndGradeInformations();
                reserveFighters[i].Deserialize(reader);
            }
        }
    }
}