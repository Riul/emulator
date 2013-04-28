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
using Emulator.Common.Protocol.Net.Types.Game.Data.Items.Effects;

namespace Emulator.Common.Protocol.Net.Types.Game.Mount
{
    public class MountClientData
    {
        public const short ID = 178;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public bool Sex { get; set; }
        public bool IsRideable { get; set; }
        public bool IsWild { get; set; }
        public bool IsFecondationReady { get; set; }
        public double Id { get; set; }
        public int Model { get; set; }
        public int[] Ancestor { get; set; }
        public int[] Behaviors { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public double Experience { get; set; }
        public double ExperienceForLevel { get; set; }
        public double ExperienceForNextLevel { get; set; }
        public sbyte Level { get; set; }
        public int MaxPods { get; set; }
        public int Stamina { get; set; }
        public int StaminaMax { get; set; }
        public int Maturity { get; set; }
        public int MaturityForAdult { get; set; }
        public int Energy { get; set; }
        public int EnergyMax { get; set; }
        public int Serenity { get; set; }
        public int AggressivityMax { get; set; }
        public int SerenityMax { get; set; }
        public int Love { get; set; }
        public int LoveMax { get; set; }
        public int FecondationTime { get; set; }
        public int BoostLimiter { get; set; }
        public double BoostMax { get; set; }
        public int ReproductionCount { get; set; }
        public int ReproductionCountMax { get; set; }
        public ObjectEffectInteger[] EffectList { get; set; }


        public MountClientData()
        {
        }

        public MountClientData(bool sex, bool isRideable, bool isWild, bool isFecondationReady, double id, int model, int[] ancestor, int[] behaviors, string name, int ownerId, double experience, double experienceForLevel, double experienceForNextLevel, sbyte level, int maxPods, int stamina, int staminaMax, int maturity, int maturityForAdult, int energy, int energyMax, int serenity, int aggressivityMax, int serenityMax, int love, int loveMax, int fecondationTime, int boostLimiter, double boostMax, int reproductionCount, int reproductionCountMax, ObjectEffectInteger[] effectList)
        {
            Sex = sex;
            IsRideable = isRideable;
            IsWild = isWild;
            IsFecondationReady = isFecondationReady;
            Id = id;
            Model = model;
            Ancestor = ancestor;
            Behaviors = behaviors;
            Name = name;
            OwnerId = ownerId;
            Experience = experience;
            ExperienceForLevel = experienceForLevel;
            ExperienceForNextLevel = experienceForNextLevel;
            Level = level;
            MaxPods = maxPods;
            Stamina = stamina;
            StaminaMax = staminaMax;
            Maturity = maturity;
            MaturityForAdult = maturityForAdult;
            Energy = energy;
            EnergyMax = energyMax;
            Serenity = serenity;
            AggressivityMax = aggressivityMax;
            SerenityMax = serenityMax;
            Love = love;
            LoveMax = loveMax;
            FecondationTime = fecondationTime;
            BoostLimiter = boostLimiter;
            BoostMax = boostMax;
            ReproductionCount = reproductionCount;
            ReproductionCountMax = reproductionCountMax;
            EffectList = effectList;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Sex);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, IsRideable);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, IsWild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, IsFecondationReady);
            writer.WriteByte(flag1);
            writer.WriteDouble(Id);
            writer.WriteInt(Model);
            writer.WriteUShort((ushort) Ancestor.Length);
            foreach (var entry in Ancestor)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort) Behaviors.Length);
            foreach (var entry in Behaviors)
            {
                writer.WriteInt(entry);
            }
            writer.WriteUTF(Name);
            writer.WriteInt(OwnerId);
            writer.WriteDouble(Experience);
            writer.WriteDouble(ExperienceForLevel);
            writer.WriteDouble(ExperienceForNextLevel);
            writer.WriteSByte(Level);
            writer.WriteInt(MaxPods);
            writer.WriteInt(Stamina);
            writer.WriteInt(StaminaMax);
            writer.WriteInt(Maturity);
            writer.WriteInt(MaturityForAdult);
            writer.WriteInt(Energy);
            writer.WriteInt(EnergyMax);
            writer.WriteInt(Serenity);
            writer.WriteInt(AggressivityMax);
            writer.WriteInt(SerenityMax);
            writer.WriteInt(Love);
            writer.WriteInt(LoveMax);
            writer.WriteInt(FecondationTime);
            writer.WriteInt(BoostLimiter);
            writer.WriteDouble(BoostMax);
            writer.WriteInt(ReproductionCount);
            writer.WriteInt(ReproductionCountMax);
            writer.WriteUShort((ushort) EffectList.Length);
            foreach (var entry in EffectList)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            byte flag1 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(flag1, 0);
            IsRideable = BooleanByteWrapper.GetFlag(flag1, 1);
            IsWild = BooleanByteWrapper.GetFlag(flag1, 2);
            IsFecondationReady = BooleanByteWrapper.GetFlag(flag1, 3);
            Id = reader.ReadDouble();
            Model = reader.ReadInt();
            var limit = reader.ReadUShort();
            Ancestor = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Ancestor[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            Behaviors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                Behaviors[i] = reader.ReadInt();
            }
            Name = reader.ReadUTF();
            OwnerId = reader.ReadInt();
            Experience = reader.ReadDouble();
            ExperienceForLevel = reader.ReadDouble();
            ExperienceForNextLevel = reader.ReadDouble();
            Level = reader.ReadSByte();
            MaxPods = reader.ReadInt();
            Stamina = reader.ReadInt();
            StaminaMax = reader.ReadInt();
            Maturity = reader.ReadInt();
            MaturityForAdult = reader.ReadInt();
            Energy = reader.ReadInt();
            EnergyMax = reader.ReadInt();
            Serenity = reader.ReadInt();
            AggressivityMax = reader.ReadInt();
            SerenityMax = reader.ReadInt();
            Love = reader.ReadInt();
            LoveMax = reader.ReadInt();
            FecondationTime = reader.ReadInt();
            BoostLimiter = reader.ReadInt();
            BoostMax = reader.ReadDouble();
            ReproductionCount = reader.ReadInt();
            ReproductionCountMax = reader.ReadInt();
            limit = reader.ReadUShort();
            EffectList = new ObjectEffectInteger[limit];
            for (int i = 0; i < limit; i++)
            {
                EffectList[i] = new ObjectEffectInteger();
                EffectList[i].Deserialize(reader);
            }
        }
    }
}