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
    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        public const uint Id = 5893;

        public CharacterMinimalPlusLookAndGradeInformations[] charactersDescription;
        public double fightId;

        public override uint MessageId
        {
            get { return Id; }
        }


        public PrismFightAttackerAddMessage()
        {
        }

        public PrismFightAttackerAddMessage(double fightId, CharacterMinimalPlusLookAndGradeInformations[] charactersDescription)
        {
            this.fightId = fightId;
            this.charactersDescription = charactersDescription;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteUShort((ushort) charactersDescription.Length);
            foreach (var entry in charactersDescription)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(BigEndianReader reader)
        {
            fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            charactersDescription = new CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                charactersDescription[i] = new CharacterMinimalPlusLookAndGradeInformations();
                charactersDescription[i].Deserialize(reader);
            }
        }
    }
}