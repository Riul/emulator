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

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic
{
    public class CharacterSpellModification
    {
        public const short ID = 215;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte ModificationType { get; set; }
        public short SpellId { get; set; }
        public CharacterBaseCharacteristic Value { get; set; }


        public CharacterSpellModification()
        {
        }

        public CharacterSpellModification(sbyte modificationType, short spellId, CharacterBaseCharacteristic value)
        {
            ModificationType = modificationType;
            SpellId = spellId;
            Value = value;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(ModificationType);
            writer.WriteShort(SpellId);
            Value.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            ModificationType = reader.ReadSByte();
            SpellId = reader.ReadShort();
            Value = new CharacterBaseCharacteristic();
            Value.Deserialize(reader);
        }
    }
}