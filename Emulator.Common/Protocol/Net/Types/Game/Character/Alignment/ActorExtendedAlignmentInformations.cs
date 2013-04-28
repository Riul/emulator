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
    public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
    {
        public const short ID = 202;

        public override short TypeId
        {
            get { return ID; }
        }

        public ushort Honor { get; set; }
        public ushort HonorGradeFloor { get; set; }
        public ushort HonorNextGradeFloor { get; set; }
        public bool PvpEnabled { get; set; }


        public ActorExtendedAlignmentInformations()
        {
        }

        public ActorExtendedAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, ushort dishonor, int characterPower, ushort honor, ushort honorGradeFloor, ushort honorNextGradeFloor, bool pvpEnabled)
                : base(alignmentSide, alignmentValue, alignmentGrade, dishonor, characterPower)
        {
            Honor = honor;
            HonorGradeFloor = honorGradeFloor;
            HonorNextGradeFloor = honorNextGradeFloor;
            PvpEnabled = pvpEnabled;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Honor);
            writer.WriteUShort(HonorGradeFloor);
            writer.WriteUShort(HonorNextGradeFloor);
            writer.WriteBoolean(PvpEnabled);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Honor = reader.ReadUShort();
            HonorGradeFloor = reader.ReadUShort();
            HonorNextGradeFloor = reader.ReadUShort();
            PvpEnabled = reader.ReadBoolean();
        }
    }
}