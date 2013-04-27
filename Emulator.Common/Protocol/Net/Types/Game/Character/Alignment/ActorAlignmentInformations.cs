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

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Alignment
{
    public class ActorAlignmentInformations
    {
        public const short Id = 201;
        public sbyte alignmentGrade;

        public sbyte alignmentSide;
        public sbyte alignmentValue;
        public int characterPower;
        public ushort dishonor;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public ActorAlignmentInformations()
        {
        }

        public ActorAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, ushort dishonor, int characterPower)
        {
            this.alignmentSide = alignmentSide;
            this.alignmentValue = alignmentValue;
            this.alignmentGrade = alignmentGrade;
            this.dishonor = dishonor;
            this.characterPower = characterPower;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteSByte(alignmentSide);
            writer.WriteSByte(alignmentValue);
            writer.WriteSByte(alignmentGrade);
            writer.WriteUShort(dishonor);
            writer.WriteInt(characterPower);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            alignmentSide = reader.ReadSByte();
            alignmentValue = reader.ReadSByte();
            if (alignmentValue < 0)
                throw new Exception("Forbidden value on alignmentValue = " + alignmentValue + ", it doesn't respect the following condition : alignmentValue < 0");
            alignmentGrade = reader.ReadSByte();
            if (alignmentGrade < 0)
                throw new Exception("Forbidden value on alignmentGrade = " + alignmentGrade + ", it doesn't respect the following condition : alignmentGrade < 0");
            dishonor = reader.ReadUShort();
            if (dishonor < 0 || dishonor > 500)
                throw new Exception("Forbidden value on dishonor = " + dishonor + ", it doesn't respect the following condition : dishonor < 0 || dishonor > 500");
            characterPower = reader.ReadInt();
            if (characterPower < 0)
                throw new Exception("Forbidden value on characterPower = " + characterPower + ", it doesn't respect the following condition : characterPower < 0");
        }
    }
}