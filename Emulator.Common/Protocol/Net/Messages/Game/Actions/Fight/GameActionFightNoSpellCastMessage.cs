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

namespace Emulator.Common.Protocol.Net.Messages.Game.Actions.Fight
{
    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        public const uint ID = 6132;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int SpellLevelId { get; set; }


        public GameActionFightNoSpellCastMessage()
        {
        }

        public GameActionFightNoSpellCastMessage(int spellLevelId)
        {
            SpellLevelId = spellLevelId;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(SpellLevelId);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            SpellLevelId = reader.ReadInt();
        }
    }
}