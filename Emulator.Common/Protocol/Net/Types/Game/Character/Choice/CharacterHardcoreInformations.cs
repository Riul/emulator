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
using Emulator.Common.Protocol.Net.Types.Game.Look;

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Choice
{
    public class CharacterHardcoreInformations : CharacterBaseInformations
    {
        public const short ID = 86;

        public override short TypeId
        {
            get { return ID; }
        }

        public sbyte DeathState { get; set; }
        public short DeathCount { get; set; }
        public byte DeathMaxLevel { get; set; }


        public CharacterHardcoreInformations()
        {
        }

        public CharacterHardcoreInformations(int id, byte level, string name, EntityLook entityLook, sbyte breed, bool sex, sbyte deathState, short deathCount, byte deathMaxLevel)
                : base(id, level, name, entityLook, breed, sex)
        {
            DeathState = deathState;
            DeathCount = deathCount;
            DeathMaxLevel = deathMaxLevel;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(DeathState);
            writer.WriteShort(DeathCount);
            writer.WriteByte(DeathMaxLevel);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            DeathState = reader.ReadSByte();
            DeathCount = reader.ReadShort();
            DeathMaxLevel = reader.ReadByte();
        }
    }
}