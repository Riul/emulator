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

namespace Emulator.Common.Protocol.Net.Messages.Game.Context.Roleplay.Spell
{
    public class SpellItemBoostMessage : NetworkMessage
    {
        public const uint ID = 6011;

        public override uint MessageId
        {
            get { return ID; }
        }

        public int StatId { get; set; }
        public short SpellId { get; set; }
        public short Value { get; set; }


        public SpellItemBoostMessage()
        {
        }

        public SpellItemBoostMessage(int statId, short spellId, short value)
        {
            StatId = statId;
            SpellId = spellId;
            Value = value;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(StatId);
            writer.WriteShort(SpellId);
            writer.WriteShort(Value);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            StatId = reader.ReadInt();
            SpellId = reader.ReadShort();
            Value = reader.ReadShort();
        }
    }
}