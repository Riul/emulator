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
    public class GameFightMinimalStats
    {
        public const short ID = 31;

        public virtual short TypeId
        {
            get { return ID; }
        }

        public int LifePoints { get; set; }
        public int MaxLifePoints { get; set; }
        public int BaseMaxLifePoints { get; set; }
        public int PermanentDamagePercent { get; set; }
        public int ShieldPoints { get; set; }
        public short ActionPoints { get; set; }
        public short MaxActionPoints { get; set; }
        public short MovementPoints { get; set; }
        public short MaxMovementPoints { get; set; }
        public int Summoner { get; set; }
        public bool Summoned { get; set; }
        public short NeutralElementResistPercent { get; set; }
        public short EarthElementResistPercent { get; set; }
        public short WaterElementResistPercent { get; set; }
        public short AirElementResistPercent { get; set; }
        public short FireElementResistPercent { get; set; }
        public short NeutralElementReduction { get; set; }
        public short EarthElementReduction { get; set; }
        public short WaterElementReduction { get; set; }
        public short AirElementReduction { get; set; }
        public short FireElementReduction { get; set; }
        public short CriticalDamageFixedResist { get; set; }
        public short PushDamageFixedResist { get; set; }
        public short DodgePALostProbability { get; set; }
        public short DodgePMLostProbability { get; set; }
        public short TackleBlock { get; set; }
        public short TackleEvade { get; set; }
        public sbyte InvisibilityState { get; set; }


        public GameFightMinimalStats()
        {
        }

        public GameFightMinimalStats(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, short actionPoints, short maxActionPoints, short movementPoints, short maxMovementPoints, int summoner, bool summoned, short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent, short airElementResistPercent, short fireElementResistPercent, short neutralElementReduction, short earthElementReduction, short waterElementReduction, short airElementReduction, short fireElementReduction, short criticalDamageFixedResist, short pushDamageFixedResist, short dodgePALostProbability, short dodgePMLostProbability, short tackleBlock, short tackleEvade, sbyte invisibilityState)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            BaseMaxLifePoints = baseMaxLifePoints;
            PermanentDamagePercent = permanentDamagePercent;
            ShieldPoints = shieldPoints;
            ActionPoints = actionPoints;
            MaxActionPoints = maxActionPoints;
            MovementPoints = movementPoints;
            MaxMovementPoints = maxMovementPoints;
            Summoner = summoner;
            Summoned = summoned;
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
            CriticalDamageFixedResist = criticalDamageFixedResist;
            PushDamageFixedResist = pushDamageFixedResist;
            DodgePALostProbability = dodgePALostProbability;
            DodgePMLostProbability = dodgePMLostProbability;
            TackleBlock = tackleBlock;
            TackleEvade = tackleEvade;
            InvisibilityState = invisibilityState;
        }


        public virtual void Serialize(BigEndianWriter writer)
        {
            writer.WriteInt(LifePoints);
            writer.WriteInt(MaxLifePoints);
            writer.WriteInt(BaseMaxLifePoints);
            writer.WriteInt(PermanentDamagePercent);
            writer.WriteInt(ShieldPoints);
            writer.WriteShort(ActionPoints);
            writer.WriteShort(MaxActionPoints);
            writer.WriteShort(MovementPoints);
            writer.WriteShort(MaxMovementPoints);
            writer.WriteInt(Summoner);
            writer.WriteBoolean(Summoned);
            writer.WriteShort(NeutralElementResistPercent);
            writer.WriteShort(EarthElementResistPercent);
            writer.WriteShort(WaterElementResistPercent);
            writer.WriteShort(AirElementResistPercent);
            writer.WriteShort(FireElementResistPercent);
            writer.WriteShort(NeutralElementReduction);
            writer.WriteShort(EarthElementReduction);
            writer.WriteShort(WaterElementReduction);
            writer.WriteShort(AirElementReduction);
            writer.WriteShort(FireElementReduction);
            writer.WriteShort(CriticalDamageFixedResist);
            writer.WriteShort(PushDamageFixedResist);
            writer.WriteShort(DodgePALostProbability);
            writer.WriteShort(DodgePMLostProbability);
            writer.WriteShort(TackleBlock);
            writer.WriteShort(TackleEvade);
            writer.WriteSByte(InvisibilityState);
        }

        public virtual void Deserialize(BigEndianReader reader)
        {
            LifePoints = reader.ReadInt();
            MaxLifePoints = reader.ReadInt();
            BaseMaxLifePoints = reader.ReadInt();
            PermanentDamagePercent = reader.ReadInt();
            ShieldPoints = reader.ReadInt();
            ActionPoints = reader.ReadShort();
            MaxActionPoints = reader.ReadShort();
            MovementPoints = reader.ReadShort();
            MaxMovementPoints = reader.ReadShort();
            Summoner = reader.ReadInt();
            Summoned = reader.ReadBoolean();
            NeutralElementResistPercent = reader.ReadShort();
            EarthElementResistPercent = reader.ReadShort();
            WaterElementResistPercent = reader.ReadShort();
            AirElementResistPercent = reader.ReadShort();
            FireElementResistPercent = reader.ReadShort();
            NeutralElementReduction = reader.ReadShort();
            EarthElementReduction = reader.ReadShort();
            WaterElementReduction = reader.ReadShort();
            AirElementReduction = reader.ReadShort();
            FireElementReduction = reader.ReadShort();
            CriticalDamageFixedResist = reader.ReadShort();
            PushDamageFixedResist = reader.ReadShort();
            DodgePALostProbability = reader.ReadShort();
            DodgePMLostProbability = reader.ReadShort();
            TackleBlock = reader.ReadShort();
            TackleEvade = reader.ReadShort();
            InvisibilityState = reader.ReadSByte();
        }
    }
}