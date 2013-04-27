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
// Created on 26/04/2013 at 16:46
#endregion

using System;
using Emulator.Common.IO;

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic
{
    public class CharacterSpellModification
    {
        public const short Id = 215;

        public sbyte modificationType;
        public short spellId;
        public CharacterBaseCharacteristic value;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public CharacterSpellModification()
        {
        }

        public CharacterSpellModification(sbyte modificationType, short spellId, CharacterBaseCharacteristic value)
        {
            this.modificationType = modificationType;
            this.spellId = spellId;
            this.value = value;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(modificationType);
            writer.WriteShort(spellId);
            value.Serialize(writer);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            modificationType = reader.ReadSByte();
            if (modificationType < 0)
                throw new Exception("Forbidden value on modificationType = " + modificationType + ", it doesn't respect the following condition : modificationType < 0");
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            value = new CharacterBaseCharacteristic();
            value.Deserialize(reader);
        }
    }
}