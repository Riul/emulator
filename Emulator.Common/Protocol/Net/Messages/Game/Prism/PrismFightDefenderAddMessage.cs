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
using Emulator.Common.Protocol.Net.Types.Game.Character;

namespace Emulator.Common.Protocol.Net.Messages.Game.Prism
{
    public class PrismFightDefenderAddMessage : NetworkMessage
    {
        public const uint ID = 5895;

        public override uint MessageId
        {
            get { return ID; }
        }

        public double FightId { get; set; }
        public CharacterMinimalPlusLookAndGradeInformations FighterMovementInformations { get; set; }
        public bool InMain { get; set; }


        public PrismFightDefenderAddMessage()
        {
        }

        public PrismFightDefenderAddMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations fighterMovementInformations, bool inMain)
        {
            FightId = fightId;
            FighterMovementInformations = fighterMovementInformations;
            InMain = inMain;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(FightId);
            FighterMovementInformations.Serialize(writer);
            writer.WriteBoolean(InMain);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            FightId = reader.ReadDouble();
            FighterMovementInformations = new CharacterMinimalPlusLookAndGradeInformations();
            FighterMovementInformations.Deserialize(reader);
            InMain = reader.ReadBoolean();
        }
    }
}