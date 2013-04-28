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
    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public const uint ID = 1010;

        public override uint MessageId
        {
            get { return ID; }
        }

        public short SpellId { get; set; }
        public sbyte SpellLevel { get; set; }


        public GameActionFightSpellCastMessage()
        {
        }

        public GameActionFightSpellCastMessage(short actionId, int sourceId, int targetId, short destinationCellId, sbyte critical, bool silentCast, short spellId, sbyte spellLevel)
                : base(actionId, sourceId, targetId, destinationCellId, critical, silentCast)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(SpellId);
            writer.WriteSByte(SpellLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadShort();
            SpellLevel = reader.ReadSByte();
        }
    }
}