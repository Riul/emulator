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

namespace Emulator.Common.Protocol.Net.Types.Game.Context.Fight
{
    public class FightResultPvpData : FightResultAdditionalData
    {
        public const short ID = 190;

        public override short TypeId
        {
            get { return ID; }
        }

        public byte Grade { get; set; }
        public ushort MinHonorForGrade { get; set; }
        public ushort MaxHonorForGrade { get; set; }
        public ushort Honor { get; set; }
        public short HonorDelta { get; set; }
        public ushort Dishonor { get; set; }
        public short DishonorDelta { get; set; }


        public FightResultPvpData()
        {
        }

        public FightResultPvpData(byte grade, ushort minHonorForGrade, ushort maxHonorForGrade, ushort honor, short honorDelta, ushort dishonor, short dishonorDelta)
        {
            Grade = grade;
            MinHonorForGrade = minHonorForGrade;
            MaxHonorForGrade = maxHonorForGrade;
            Honor = honor;
            HonorDelta = honorDelta;
            Dishonor = dishonor;
            DishonorDelta = dishonorDelta;
        }


        public override void Serialize(BigEndianWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Grade);
            writer.WriteUShort(MinHonorForGrade);
            writer.WriteUShort(MaxHonorForGrade);
            writer.WriteUShort(Honor);
            writer.WriteShort(HonorDelta);
            writer.WriteUShort(Dishonor);
            writer.WriteShort(DishonorDelta);
        }

        public override void Deserialize(BigEndianReader reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadByte();
            MinHonorForGrade = reader.ReadUShort();
            MaxHonorForGrade = reader.ReadUShort();
            Honor = reader.ReadUShort();
            HonorDelta = reader.ReadShort();
            Dishonor = reader.ReadUShort();
            DishonorDelta = reader.ReadShort();
        }
    }
}