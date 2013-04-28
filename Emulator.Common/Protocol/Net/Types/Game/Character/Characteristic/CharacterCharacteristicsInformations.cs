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
using Emulator.Common.Protocol.Net.Types.Game.Character.Alignment;

namespace Emulator.Common.Protocol.Net.Types.Game.Character.Characteristic
{
    public class CharacterCharacteristicsInformations
    {
        public const short ID = 8;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public double Experience { get; set; }
        public double ExperienceLevelFloor { get; set; }
        public double ExperienceNextLevelFloor { get; set; }
        public int Kamas { get; set; }
        public int StatsPoints { get; set; }
        public int SpellsPoints { get; set; }
        public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }
        public int LifePoints { get; set; }
        public int MaxLifePoints { get; set; }
        public short EnergyPoints { get; set; }
        public short MaxEnergyPoints { get; set; }
        public short ActionPointsCurrent { get; set; }
        public short MovementPointsCurrent { get; set; }
        public CharacterBaseCharacteristic Initiative { get; set; }
        public CharacterBaseCharacteristic Prospecting { get; set; }
        public CharacterBaseCharacteristic ActionPoints { get; set; }
        public CharacterBaseCharacteristic MovementPoints { get; set; }
        public CharacterBaseCharacteristic Strength { get; set; }
        public CharacterBaseCharacteristic Vitality { get; set; }
        public CharacterBaseCharacteristic Wisdom { get; set; }
        public CharacterBaseCharacteristic Chance { get; set; }
        public CharacterBaseCharacteristic Agility { get; set; }
        public CharacterBaseCharacteristic Intelligence { get; set; }
        public CharacterBaseCharacteristic Range { get; set; }
        public CharacterBaseCharacteristic SummonableCreaturesBoost { get; set; }
        public CharacterBaseCharacteristic Reflect { get; set; }
        public CharacterBaseCharacteristic CriticalHit { get; set; }
        public short CriticalHitWeapon { get; set; }
        public CharacterBaseCharacteristic CriticalMiss { get; set; }
        public CharacterBaseCharacteristic HealBonus { get; set; }
        public CharacterBaseCharacteristic AllDamagesBonus { get; set; }
        public CharacterBaseCharacteristic WeaponDamagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic DamagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic TrapBonus { get; set; }
        public CharacterBaseCharacteristic TrapBonusPercent { get; set; }
        public CharacterBaseCharacteristic PermanentDamagePercent { get; set; }
        public CharacterBaseCharacteristic TackleBlock { get; set; }
        public CharacterBaseCharacteristic TackleEvade { get; set; }
        public CharacterBaseCharacteristic PAAttack { get; set; }
        public CharacterBaseCharacteristic PMAttack { get; set; }
        public CharacterBaseCharacteristic PushDamageBonus { get; set; }
        public CharacterBaseCharacteristic CriticalDamageBonus { get; set; }
        public CharacterBaseCharacteristic NeutralDamageBonus { get; set; }
        public CharacterBaseCharacteristic EarthDamageBonus { get; set; }
        public CharacterBaseCharacteristic WaterDamageBonus { get; set; }
        public CharacterBaseCharacteristic AirDamageBonus { get; set; }
        public CharacterBaseCharacteristic FireDamageBonus { get; set; }
        public CharacterBaseCharacteristic DodgePALostProbability { get; set; }
        public CharacterBaseCharacteristic DodgePMLostProbability { get; set; }
        public CharacterBaseCharacteristic NeutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic EarthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic WaterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic AirElementResistPercent { get; set; }
        public CharacterBaseCharacteristic FireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic NeutralElementReduction { get; set; }
        public CharacterBaseCharacteristic EarthElementReduction { get; set; }
        public CharacterBaseCharacteristic WaterElementReduction { get; set; }
        public CharacterBaseCharacteristic AirElementReduction { get; set; }
        public CharacterBaseCharacteristic FireElementReduction { get; set; }
        public CharacterBaseCharacteristic PushDamageReduction { get; set; }
        public CharacterBaseCharacteristic CriticalDamageReduction { get; set; }
        public CharacterBaseCharacteristic PvpNeutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpEarthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpWaterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpAirElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpFireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpNeutralElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpEarthElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpWaterElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpAirElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpFireElementReduction { get; set; }
        public CharacterSpellModification[] SpellModifications { get; set; }


        public CharacterCharacteristicsInformations()
        {
        }

        public CharacterCharacteristicsInformations(double experience, double experienceLevelFloor, double experienceNextLevelFloor, int kamas, int statsPoints, int spellsPoints, ActorExtendedAlignmentInformations alignmentInfos, int lifePoints, int maxLifePoints, short energyPoints, short maxEnergyPoints, short actionPointsCurrent, short movementPointsCurrent, CharacterBaseCharacteristic initiative, CharacterBaseCharacteristic prospecting, CharacterBaseCharacteristic actionPoints, CharacterBaseCharacteristic movementPoints, CharacterBaseCharacteristic strength, CharacterBaseCharacteristic vitality, CharacterBaseCharacteristic wisdom, CharacterBaseCharacteristic chance, CharacterBaseCharacteristic agility, CharacterBaseCharacteristic intelligence, CharacterBaseCharacteristic range, CharacterBaseCharacteristic summonableCreaturesBoost, CharacterBaseCharacteristic reflect, CharacterBaseCharacteristic criticalHit, short criticalHitWeapon, CharacterBaseCharacteristic criticalMiss, CharacterBaseCharacteristic healBonus, CharacterBaseCharacteristic allDamagesBonus, CharacterBaseCharacteristic weaponDamagesBonusPercent, CharacterBaseCharacteristic damagesBonusPercent, CharacterBaseCharacteristic trapBonus, CharacterBaseCharacteristic trapBonusPercent, CharacterBaseCharacteristic permanentDamagePercent, CharacterBaseCharacteristic tackleBlock, CharacterBaseCharacteristic tackleEvade, CharacterBaseCharacteristic PAAttack, CharacterBaseCharacteristic PMAttack, CharacterBaseCharacteristic pushDamageBonus, CharacterBaseCharacteristic criticalDamageBonus, CharacterBaseCharacteristic neutralDamageBonus, CharacterBaseCharacteristic earthDamageBonus, CharacterBaseCharacteristic waterDamageBonus, CharacterBaseCharacteristic airDamageBonus, CharacterBaseCharacteristic fireDamageBonus, CharacterBaseCharacteristic dodgePALostProbability, CharacterBaseCharacteristic dodgePMLostProbability, CharacterBaseCharacteristic neutralElementResistPercent, CharacterBaseCharacteristic earthElementResistPercent, CharacterBaseCharacteristic waterElementResistPercent, CharacterBaseCharacteristic airElementResistPercent, CharacterBaseCharacteristic fireElementResistPercent, CharacterBaseCharacteristic neutralElementReduction, CharacterBaseCharacteristic earthElementReduction, CharacterBaseCharacteristic waterElementReduction, CharacterBaseCharacteristic airElementReduction, CharacterBaseCharacteristic fireElementReduction, CharacterBaseCharacteristic pushDamageReduction, CharacterBaseCharacteristic criticalDamageReduction, CharacterBaseCharacteristic pvpNeutralElementResistPercent, CharacterBaseCharacteristic pvpEarthElementResistPercent, CharacterBaseCharacteristic pvpWaterElementResistPercent, CharacterBaseCharacteristic pvpAirElementResistPercent, CharacterBaseCharacteristic pvpFireElementResistPercent, CharacterBaseCharacteristic pvpNeutralElementReduction, CharacterBaseCharacteristic pvpEarthElementReduction, CharacterBaseCharacteristic pvpWaterElementReduction, CharacterBaseCharacteristic pvpAirElementReduction, CharacterBaseCharacteristic pvpFireElementReduction, CharacterSpellModification[] spellModifications)
        {
            Experience = experience;
            ExperienceLevelFloor = experienceLevelFloor;
            ExperienceNextLevelFloor = experienceNextLevelFloor;
            Kamas = kamas;
            StatsPoints = statsPoints;
            SpellsPoints = spellsPoints;
            AlignmentInfos = alignmentInfos;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            EnergyPoints = energyPoints;
            MaxEnergyPoints = maxEnergyPoints;
            ActionPointsCurrent = actionPointsCurrent;
            MovementPointsCurrent = movementPointsCurrent;
            Initiative = initiative;
            Prospecting = prospecting;
            ActionPoints = actionPoints;
            MovementPoints = movementPoints;
            Strength = strength;
            Vitality = vitality;
            Wisdom = wisdom;
            Chance = chance;
            Agility = agility;
            Intelligence = intelligence;
            Range = range;
            SummonableCreaturesBoost = summonableCreaturesBoost;
            Reflect = reflect;
            CriticalHit = criticalHit;
            CriticalHitWeapon = criticalHitWeapon;
            CriticalMiss = criticalMiss;
            HealBonus = healBonus;
            AllDamagesBonus = allDamagesBonus;
            WeaponDamagesBonusPercent = weaponDamagesBonusPercent;
            DamagesBonusPercent = damagesBonusPercent;
            TrapBonus = trapBonus;
            TrapBonusPercent = trapBonusPercent;
            PermanentDamagePercent = permanentDamagePercent;
            TackleBlock = tackleBlock;
            TackleEvade = tackleEvade;
            this.PAAttack = PAAttack;
            this.PMAttack = PMAttack;
            PushDamageBonus = pushDamageBonus;
            CriticalDamageBonus = criticalDamageBonus;
            NeutralDamageBonus = neutralDamageBonus;
            EarthDamageBonus = earthDamageBonus;
            WaterDamageBonus = waterDamageBonus;
            AirDamageBonus = airDamageBonus;
            FireDamageBonus = fireDamageBonus;
            DodgePALostProbability = dodgePALostProbability;
            DodgePMLostProbability = dodgePMLostProbability;
            NeutralElementResistPercent = neutralElementResistPercent;
            EarthElementResistPercent = earthElementResistPercent;
            WaterElementResistPercent = waterElementResistPercent;
            AirElementResistPercent = airElementResistPercent;
            FireElementResistPercent = fireElementResistPercent;
            NeutralElementReduction = neutralElementReduction;
            EarthElementReduction = earthElementReduction;
            WaterElementReduction = waterElementReduction;
            AirElementReduction = airElementReduction;
            FireElementReduction = fireElementReduction;
            PushDamageReduction = pushDamageReduction;
            CriticalDamageReduction = criticalDamageReduction;
            PvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            PvpEarthElementResistPercent = pvpEarthElementResistPercent;
            PvpWaterElementResistPercent = pvpWaterElementResistPercent;
            PvpAirElementResistPercent = pvpAirElementResistPercent;
            PvpFireElementResistPercent = pvpFireElementResistPercent;
            PvpNeutralElementReduction = pvpNeutralElementReduction;
            PvpEarthElementReduction = pvpEarthElementReduction;
            PvpWaterElementReduction = pvpWaterElementReduction;
            PvpAirElementReduction = pvpAirElementReduction;
            PvpFireElementReduction = pvpFireElementReduction;
            SpellModifications = spellModifications;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteDouble(Experience);
            writer.WriteDouble(ExperienceLevelFloor);
            writer.WriteDouble(ExperienceNextLevelFloor);
            writer.WriteInt(Kamas);
            writer.WriteInt(StatsPoints);
            writer.WriteInt(SpellsPoints);
            AlignmentInfos.Serialize(writer);
            writer.WriteInt(LifePoints);
            writer.WriteInt(MaxLifePoints);
            writer.WriteShort(EnergyPoints);
            writer.WriteShort(MaxEnergyPoints);
            writer.WriteShort(ActionPointsCurrent);
            writer.WriteShort(MovementPointsCurrent);
            Initiative.Serialize(writer);
            Prospecting.Serialize(writer);
            ActionPoints.Serialize(writer);
            MovementPoints.Serialize(writer);
            Strength.Serialize(writer);
            Vitality.Serialize(writer);
            Wisdom.Serialize(writer);
            Chance.Serialize(writer);
            Agility.Serialize(writer);
            Intelligence.Serialize(writer);
            Range.Serialize(writer);
            SummonableCreaturesBoost.Serialize(writer);
            Reflect.Serialize(writer);
            CriticalHit.Serialize(writer);
            writer.WriteShort(CriticalHitWeapon);
            CriticalMiss.Serialize(writer);
            HealBonus.Serialize(writer);
            AllDamagesBonus.Serialize(writer);
            WeaponDamagesBonusPercent.Serialize(writer);
            DamagesBonusPercent.Serialize(writer);
            TrapBonus.Serialize(writer);
            TrapBonusPercent.Serialize(writer);
            PermanentDamagePercent.Serialize(writer);
            TackleBlock.Serialize(writer);
            TackleEvade.Serialize(writer);
            PAAttack.Serialize(writer);
            PMAttack.Serialize(writer);
            PushDamageBonus.Serialize(writer);
            CriticalDamageBonus.Serialize(writer);
            NeutralDamageBonus.Serialize(writer);
            EarthDamageBonus.Serialize(writer);
            WaterDamageBonus.Serialize(writer);
            AirDamageBonus.Serialize(writer);
            FireDamageBonus.Serialize(writer);
            DodgePALostProbability.Serialize(writer);
            DodgePMLostProbability.Serialize(writer);
            NeutralElementResistPercent.Serialize(writer);
            EarthElementResistPercent.Serialize(writer);
            WaterElementResistPercent.Serialize(writer);
            AirElementResistPercent.Serialize(writer);
            FireElementResistPercent.Serialize(writer);
            NeutralElementReduction.Serialize(writer);
            EarthElementReduction.Serialize(writer);
            WaterElementReduction.Serialize(writer);
            AirElementReduction.Serialize(writer);
            FireElementReduction.Serialize(writer);
            PushDamageReduction.Serialize(writer);
            CriticalDamageReduction.Serialize(writer);
            PvpNeutralElementResistPercent.Serialize(writer);
            PvpEarthElementResistPercent.Serialize(writer);
            PvpWaterElementResistPercent.Serialize(writer);
            PvpAirElementResistPercent.Serialize(writer);
            PvpFireElementResistPercent.Serialize(writer);
            PvpNeutralElementReduction.Serialize(writer);
            PvpEarthElementReduction.Serialize(writer);
            PvpWaterElementReduction.Serialize(writer);
            PvpAirElementReduction.Serialize(writer);
            PvpFireElementReduction.Serialize(writer);
            writer.WriteUShort((ushort) SpellModifications.Length);
            foreach (var entry in SpellModifications)
            {
                entry.Serialize(writer);
            }
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            Experience = reader.ReadDouble();
            ExperienceLevelFloor = reader.ReadDouble();
            ExperienceNextLevelFloor = reader.ReadDouble();
            Kamas = reader.ReadInt();
            StatsPoints = reader.ReadInt();
            SpellsPoints = reader.ReadInt();
            AlignmentInfos = new ActorExtendedAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            LifePoints = reader.ReadInt();
            MaxLifePoints = reader.ReadInt();
            EnergyPoints = reader.ReadShort();
            MaxEnergyPoints = reader.ReadShort();
            ActionPointsCurrent = reader.ReadShort();
            MovementPointsCurrent = reader.ReadShort();
            Initiative = new CharacterBaseCharacteristic();
            Initiative.Deserialize(reader);
            Prospecting = new CharacterBaseCharacteristic();
            Prospecting.Deserialize(reader);
            ActionPoints = new CharacterBaseCharacteristic();
            ActionPoints.Deserialize(reader);
            MovementPoints = new CharacterBaseCharacteristic();
            MovementPoints.Deserialize(reader);
            Strength = new CharacterBaseCharacteristic();
            Strength.Deserialize(reader);
            Vitality = new CharacterBaseCharacteristic();
            Vitality.Deserialize(reader);
            Wisdom = new CharacterBaseCharacteristic();
            Wisdom.Deserialize(reader);
            Chance = new CharacterBaseCharacteristic();
            Chance.Deserialize(reader);
            Agility = new CharacterBaseCharacteristic();
            Agility.Deserialize(reader);
            Intelligence = new CharacterBaseCharacteristic();
            Intelligence.Deserialize(reader);
            Range = new CharacterBaseCharacteristic();
            Range.Deserialize(reader);
            SummonableCreaturesBoost = new CharacterBaseCharacteristic();
            SummonableCreaturesBoost.Deserialize(reader);
            Reflect = new CharacterBaseCharacteristic();
            Reflect.Deserialize(reader);
            CriticalHit = new CharacterBaseCharacteristic();
            CriticalHit.Deserialize(reader);
            CriticalHitWeapon = reader.ReadShort();
            CriticalMiss = new CharacterBaseCharacteristic();
            CriticalMiss.Deserialize(reader);
            HealBonus = new CharacterBaseCharacteristic();
            HealBonus.Deserialize(reader);
            AllDamagesBonus = new CharacterBaseCharacteristic();
            AllDamagesBonus.Deserialize(reader);
            WeaponDamagesBonusPercent = new CharacterBaseCharacteristic();
            WeaponDamagesBonusPercent.Deserialize(reader);
            DamagesBonusPercent = new CharacterBaseCharacteristic();
            DamagesBonusPercent.Deserialize(reader);
            TrapBonus = new CharacterBaseCharacteristic();
            TrapBonus.Deserialize(reader);
            TrapBonusPercent = new CharacterBaseCharacteristic();
            TrapBonusPercent.Deserialize(reader);
            PermanentDamagePercent = new CharacterBaseCharacteristic();
            PermanentDamagePercent.Deserialize(reader);
            TackleBlock = new CharacterBaseCharacteristic();
            TackleBlock.Deserialize(reader);
            TackleEvade = new CharacterBaseCharacteristic();
            TackleEvade.Deserialize(reader);
            PAAttack = new CharacterBaseCharacteristic();
            PAAttack.Deserialize(reader);
            PMAttack = new CharacterBaseCharacteristic();
            PMAttack.Deserialize(reader);
            PushDamageBonus = new CharacterBaseCharacteristic();
            PushDamageBonus.Deserialize(reader);
            CriticalDamageBonus = new CharacterBaseCharacteristic();
            CriticalDamageBonus.Deserialize(reader);
            NeutralDamageBonus = new CharacterBaseCharacteristic();
            NeutralDamageBonus.Deserialize(reader);
            EarthDamageBonus = new CharacterBaseCharacteristic();
            EarthDamageBonus.Deserialize(reader);
            WaterDamageBonus = new CharacterBaseCharacteristic();
            WaterDamageBonus.Deserialize(reader);
            AirDamageBonus = new CharacterBaseCharacteristic();
            AirDamageBonus.Deserialize(reader);
            FireDamageBonus = new CharacterBaseCharacteristic();
            FireDamageBonus.Deserialize(reader);
            DodgePALostProbability = new CharacterBaseCharacteristic();
            DodgePALostProbability.Deserialize(reader);
            DodgePMLostProbability = new CharacterBaseCharacteristic();
            DodgePMLostProbability.Deserialize(reader);
            NeutralElementResistPercent = new CharacterBaseCharacteristic();
            NeutralElementResistPercent.Deserialize(reader);
            EarthElementResistPercent = new CharacterBaseCharacteristic();
            EarthElementResistPercent.Deserialize(reader);
            WaterElementResistPercent = new CharacterBaseCharacteristic();
            WaterElementResistPercent.Deserialize(reader);
            AirElementResistPercent = new CharacterBaseCharacteristic();
            AirElementResistPercent.Deserialize(reader);
            FireElementResistPercent = new CharacterBaseCharacteristic();
            FireElementResistPercent.Deserialize(reader);
            NeutralElementReduction = new CharacterBaseCharacteristic();
            NeutralElementReduction.Deserialize(reader);
            EarthElementReduction = new CharacterBaseCharacteristic();
            EarthElementReduction.Deserialize(reader);
            WaterElementReduction = new CharacterBaseCharacteristic();
            WaterElementReduction.Deserialize(reader);
            AirElementReduction = new CharacterBaseCharacteristic();
            AirElementReduction.Deserialize(reader);
            FireElementReduction = new CharacterBaseCharacteristic();
            FireElementReduction.Deserialize(reader);
            PushDamageReduction = new CharacterBaseCharacteristic();
            PushDamageReduction.Deserialize(reader);
            CriticalDamageReduction = new CharacterBaseCharacteristic();
            CriticalDamageReduction.Deserialize(reader);
            PvpNeutralElementResistPercent = new CharacterBaseCharacteristic();
            PvpNeutralElementResistPercent.Deserialize(reader);
            PvpEarthElementResistPercent = new CharacterBaseCharacteristic();
            PvpEarthElementResistPercent.Deserialize(reader);
            PvpWaterElementResistPercent = new CharacterBaseCharacteristic();
            PvpWaterElementResistPercent.Deserialize(reader);
            PvpAirElementResistPercent = new CharacterBaseCharacteristic();
            PvpAirElementResistPercent.Deserialize(reader);
            PvpFireElementResistPercent = new CharacterBaseCharacteristic();
            PvpFireElementResistPercent.Deserialize(reader);
            PvpNeutralElementReduction = new CharacterBaseCharacteristic();
            PvpNeutralElementReduction.Deserialize(reader);
            PvpEarthElementReduction = new CharacterBaseCharacteristic();
            PvpEarthElementReduction.Deserialize(reader);
            PvpWaterElementReduction = new CharacterBaseCharacteristic();
            PvpWaterElementReduction.Deserialize(reader);
            PvpAirElementReduction = new CharacterBaseCharacteristic();
            PvpAirElementReduction.Deserialize(reader);
            PvpFireElementReduction = new CharacterBaseCharacteristic();
            PvpFireElementReduction.Deserialize(reader);
            var limit = reader.ReadUShort();
            SpellModifications = new CharacterSpellModification[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellModifications[i] = new CharacterSpellModification();
                SpellModifications[i].Deserialize(reader);
            }
        }
    }
}