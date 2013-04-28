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

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Alignment
{
    public class ActorAlignmentInformations
    {
        public const short ID = 201;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public sbyte AlignmentSide { get; set; }
        public sbyte AlignmentValue { get; set; }
        public sbyte AlignmentGrade { get; set; }
        public ushort Dishonor { get; set; }
        public int CharacterPower { get; set; }


        public ActorAlignmentInformations()
        {
        }

        public ActorAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, ushort dishonor, int characterPower)
        {
            AlignmentSide = alignmentSide;
            AlignmentValue = alignmentValue;
            AlignmentGrade = alignmentGrade;
            Dishonor = dishonor;
            CharacterPower = characterPower;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(AlignmentValue);
            writer.WriteSByte(AlignmentGrade);
            writer.WriteUShort(Dishonor);
            writer.WriteInt(CharacterPower);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            AlignmentSide = reader.ReadSByte();
            AlignmentValue = reader.ReadSByte();
            AlignmentGrade = reader.ReadSByte();
            Dishonor = reader.ReadUShort();
            CharacterPower = reader.ReadInt();
        }
    }
}