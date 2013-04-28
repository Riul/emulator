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
    public class CharacterBaseCharacteristic
    {
        public const short ID = 4;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public short @base { get; set; }
        public short ObjectsAndMountBonus { get; set; }
        public short AlignGiftBonus { get; set; }
        public short ContextModif { get; set; }


        public CharacterBaseCharacteristic()
        {
        }

        public CharacterBaseCharacteristic(short @base, short objectsAndMountBonus, short alignGiftBonus, short contextModif)
        {
            this.@base = @base;
            ObjectsAndMountBonus = objectsAndMountBonus;
            AlignGiftBonus = alignGiftBonus;
            ContextModif = contextModif;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteShort(@base);
            writer.WriteShort(ObjectsAndMountBonus);
            writer.WriteShort(AlignGiftBonus);
            writer.WriteShort(ContextModif);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            @base = reader.ReadShort();
            ObjectsAndMountBonus = reader.ReadShort();
            AlignGiftBonus = reader.ReadShort();
            ContextModif = reader.ReadShort();
        }
    }
}